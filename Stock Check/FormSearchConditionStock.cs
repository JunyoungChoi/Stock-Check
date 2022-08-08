using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AxGIEXPERTCONTROLLib;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;
using System.Net.Mail;
using JY.ExtensionMethods;

namespace JY.StockChecker
{
    public partial class FormSearchConditionStock : Form
    {
        private GiController _giController;

        private Label forAck;

        #region enum
        public enum TR
        {
            TR_1206,    // 종목별 기간 거래량 투자자별 고/저가 확인
            TR_1870,    // 이격도
            TR_SCHART,  // 시간별 체결량 및 거래대금
        }

        #endregion

        #region Properties
        public TR CurrentTR { get { return _currentTR; } }
        public bool IsSequence { get { return !dataGridView_Step.Rows[0].Cells[0].Value.ToString().Equals("No"); } }

        #endregion

        public List<string[]> ReceiveData;
        public Dictionary<string, string[]> Egyukdo;
        PointF minMax5;
        PointF minMax20;
        PointF minMax60;
        PointF minMax120;
        float tradingMoneyVolume;
        public Dictionary<string, string[]> TradingMoneyVolume;

        private Dictionary<string, int> gamsiList;

        public int DataLength
        {
            get
            {
                switch (_currentTR)
                {
                    case TR.TR_1206:
                        return 94;
                    case TR.TR_1870:
                        return 11;
                    case TR.TR_SCHART:
                        return 11;
                    default:
                        return 11;
                }
            }
        }

        private bool TradingVolumeAck = false;
        private readonly string modulePath = Application.StartupPath;
        private readonly string indiPath = @"C:\SHINHAN-i\indi\giexpertstarter.exe";
        private TR _currentTR;
        private const int c_legendItemHeight = 20;
        private const string c_checkCustomPropertyName = "CHECK";
        private const string c_checkedString = "✔"; // see http://www.edlazorvfx.com/ysu/html/ascii.html for more
        private const string c_uncheckedString = "✘";

        FormRTCheck formRTGamsi;

        public delegate void StopRTGamsiing();
        public event StopRTGamsiing StopRTGamsi;

        public FormSearchConditionStock()
        {
            InitializeComponent();

            ReceiveData = new List<string[]>();
            Egyukdo = new Dictionary<string, string[]>();
            TradingMoneyVolume = new Dictionary<string, string[]>();
            axGiExpertControl.ReceiveData += Indi_ReceiveData;

            formRTGamsi = new FormRTCheck(this.axGiExpertControl);

            StopRTGamsi += formRTGamsi.FormRTGamsi_StopGamsi;
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            axGiExpertControl.RequestRTReg("SC", textBox1.Text);
        }

        private void Indi_ReceiveData(object sender, _DGiExpertControlEvents_ReceiveDataEvent e)
        {
            Debug.WriteLine("Indi_ReceiveData");

            int row = axGiExpertControl.GetMultiRowCount();
            int column = DataLength;

            ReceiveData.Clear();

            for (int i = 0; i < row; i++)
            {
                string[] data = new string[column];

                for (int j = 0; j < column; j++)
                {
                    data[j] = axGiExpertControl.GetMultiData((short)i, (short)j).ToString();
                }

                ReceiveData.Add(data);
            }

            forAck.Visible = true;
        }


        private void SetQuery(TR query)
        {
            axGiExpertControl.SetQueryName(query.ToString());
            _currentTR = query;
        }

        private void SetInput(params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                axGiExpertControl.SetSingleData((short)i, parameters[i].ToString());
            }
        }

        private void Request()
        {
            Debug.WriteLine("Request");

            axGiExpertControl.RequestData();
        }

        


        private Dictionary<string, string[]> Sieve_Egyukdo(PointF five, PointF twenty, PointF sixty, PointF hundredTwenty, float tradingMoneyVolume)
        {
            Dictionary<string, string[]> sieveResult = new Dictionary<string, string[]>();


            var sieveData = from data in ReceiveData
                            where five.X <= float.Parse(data[6]) && float.Parse(data[6]) <= five.Y 
                                  && twenty.X <= float.Parse(data[7]) && float.Parse(data[7]) <= twenty.Y 
                                  && sixty.X <= float.Parse(data[8]) && float.Parse(data[8]) <= sixty.Y 
                                  && hundredTwenty.X <= float.Parse(data[9]) && float.Parse(data[9]) <= hundredTwenty.Y
                                  && !data[3].Equals("3") 
                                  && float.Parse(data[2]) * float.Parse(data[5]) >= tradingMoneyVolume * 100000000
                                  && float.Parse(data[6]) * 0.97 <= float.Parse(data[7]) && float.Parse(data[7]) <= float.Parse(data[6]) * 1.05
                                  && float.Parse(data[6]) * 1.05 <= float.Parse(data[8])
                            //&& float.Parse(data[4]) <= float.Parse(data[2]) / 100.0 * 4
                            select data;

            foreach (string[] data in sieveData)
            {
                float f = float.Parse(data[6]);
                float t = float.Parse(data[7]);
                float s = float.Parse(data[8]);
                float h = float.Parse(data[9]);

                sieveResult[data[1]] = new string[] { data[0], data[6], data[7], data[8], data[9] };
            }

            return sieveResult;
        }

        /// <summary>
        /// 이격도 - 우상향
        /// 1. 95% <= 5일
        /// 2. 95% <= 20일 <= 100
        /// 3. 90% <= 60일 <= 100
        /// 4. 5일 >= 20일 >= 60일
        /// </summary>
        private void Sequence_Egyukdo1()
        {
            #region 조건
            /// 이격도 - 우상향
            /// 1. 95% <= 5일
            /// 2. 95% <= 20일 <= 100
            /// 3. 90% <= 60일 <= 100
            /// 4. 5일 >= 20일 >= 60일

            Point minMax5 = new Point(95, 500);
            Point minMax20 = new Point(95, 103);
            Point minMax60 = new Point(90, 103);
            Point minMax120 = new Point(0, 500);
            float tradingMoneyVolume = 7;
            bool isOrder = true;

            Sequence_Egyukdo(minMax5, minMax20, minMax60, minMax120, tradingMoneyVolume);

            #endregion
        }

        private void getWholeStock()
        {
            #region 이격도 조건 request  TR_1870
            SetQuery(TR.TR_1870);

            //  0 : KOSPI   1 : KOSDAQ  2 : 전체
            //  0 : 5일     1 : 20일    2 : 60일   4 : 120일
            //  최소
            //  최대
            SetInput(2, 0, 0, 500);

            Request();
            #endregion
        }


        

        

        private void button_Sequence_Click(object sender, EventArgs e)
        {
                    button_Sequence.Enabled = false;
            label14.Text = $"계산중";

            dataGridView_Recommand.Rows.Clear();

            ChangeStep(Step.Egyukdo);
        }

        public enum Step
        {
            No,
            Egyukdo,
            TradingMoneyVolume,
            TradingVolume
        }

        private void ChangeStep(Step step)
        {
            dataGridView_Step.Rows[0].Cells[0].Value = step.ToString();
        }

        private void button_Egyukdo_Click(object sender, EventArgs e)
        {
            Step1();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _giController = new GiController(this.axGiExpertControl);

            dataGridView_Step.Rows[0].Cells[0].Value = "No";

            forAck = new Label();
            forAck.Visible = false;
            forAck.VisibleChanged += ForAck_VisibleChanged;

            ExtensionMethods.ExtensionMethods.DoubleBuffered(dataGridView_Egyukdo, true);
            ExtensionMethods.ExtensionMethods.DoubleBuffered(dataGridView_TradingMoneyVolume, true);
            ExtensionMethods.ExtensionMethods.DoubleBuffered(dataGridView_Recommand, true);

            chart1.Series.Clear();
        }

        private void ForAck_VisibleChanged(object sender, EventArgs e)
        {
            if (forAck.Visible)
            {
                if (IsSequence)
                {
                    switch (_currentTR)
                    {
                        case TR.TR_1870:
                            Egyukdo = Sieve_Egyukdo(minMax5, minMax20, minMax60, minMax120, tradingMoneyVolume);
                            DisplayEgyukdo2();
                            dataGridView_Recommand.Enabled = true;
                            ChangeStep(Step.TradingMoneyVolume);
                            break;
                        case TR.TR_SCHART:
                            DisplayTradingMoneyVolume2(Sieve_TradingMoneyVolume());
                            label14.Text = $"총 {dataGridView_Recommand.RowCount}개";
                            break;
                        case TR.TR_1206:
                            DrawChart();
                            dataGridView_Recommand.Enabled = true;
                            ChangeStep(Step.No);
                            break;

                    }
                }
                else
                {
                    switch (_currentTR)
                    {
                        case TR.TR_1870:
                            Egyukdo = Sieve_Egyukdo(minMax5, minMax20, minMax60, minMax120, tradingMoneyVolume);
                            DisplayEgyukdo();
                            break;
                        case TR.TR_SCHART:
                            DisplayTradingMoneyVolume();
                            break;
                        case TR.TR_1206:

                            break;

                    }
                }

                forAck.Visible = false;
            }
        }

        private int recommandIndex = 0;

        private void DisplayTradingMoneyVolume2(bool check)
        {
            if (!check)
            {
                Debug.WriteLine($"DELETE : {dataGridView_Recommand.Rows[recommandIndex].Cells[0].Value}");
                dataGridView_Recommand.Rows.RemoveAt(recommandIndex);
            }

            TradingVolumeAck = true;
        }


        private bool Sieve_TradingMoneyVolume()
        {
            float moneyVolume = 0;
            int moneyCount = 0;

            if (!int.TryParse(textBox_TradingMoneyCount.Text, out moneyCount))
            {
                moneyCount = 5;
            }

            if (!float.TryParse(textBox_TradingMoney2.Text, out moneyVolume))
            {
                moneyVolume = 7.0f;
            }

            var sieveData = from data in ReceiveData
                            where float.Parse(data[10]) >= moneyVolume * 100000000
                            select data;

            return sieveData.Count() >= moneyCount;
        }

        private void DisplayTradingMoneyVolume()
        {
            dataGridView_TradingMoneyVolume.Rows.Clear();

            foreach (string[] data in ReceiveData)
            {
                int rowIndex = dataGridView_TradingMoneyVolume.Rows.Add();

                dataGridView_TradingMoneyVolume.Rows[rowIndex].Cells["Column_Date"].Value = data[0];
                dataGridView_TradingMoneyVolume.Rows[rowIndex].Cells["Column_Start"].Value = data[2];
                dataGridView_TradingMoneyVolume.Rows[rowIndex].Cells["Column_High"].Value = data[3];
                dataGridView_TradingMoneyVolume.Rows[rowIndex].Cells["Column_Low"].Value = data[4];
                dataGridView_TradingMoneyVolume.Rows[rowIndex].Cells["Column_Current"].Value = data[5];
                dataGridView_TradingMoneyVolume.Rows[rowIndex].Cells["Column_TradingMoneyVolume"].Value = (float.Parse(data[10]) / 100000000.0);
            }
        }

        private void DisplayEgyukdo2()
        {
            foreach (string name in Egyukdo.Keys)
            {
                int rowIndex = dataGridView_Recommand.Rows.Add();

                dataGridView_Recommand.Rows[rowIndex].Cells[0].Value = name.Trim();
                dataGridView_Recommand.Rows[rowIndex].Cells[1].Value = Egyukdo[name][0];

                Debug.WriteLine($"{name} : {Egyukdo[name][1]}\t{Egyukdo[name][2]}\t{Egyukdo[name][3]}\t{Egyukdo[name][4]}");
            }
        }


        private void DisplayEgyukdo()
        {
            dataGridView_Egyukdo.Rows.Clear();

            bool isShowAll = true;

            if (Egyukdo.Count > 99)
            {
                if (MessageBox.Show("100개가 넘습니다. 다 보여줍니까?", $"총 {Egyukdo.Count} 개", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    isShowAll = false;
                }
            }

            foreach (string name in Egyukdo.Keys)
            {
                int rowIndex = dataGridView_Egyukdo.Rows.Add();

                dataGridView_Egyukdo.Rows[rowIndex].Cells["Column_Name"].Value = name.Trim();
                dataGridView_Egyukdo.Rows[rowIndex].Cells["Column_ShortCode"].Value = Egyukdo[name][0];
                dataGridView_Egyukdo.Rows[rowIndex].Cells["Column_Five"].Value = Egyukdo[name][1];
                dataGridView_Egyukdo.Rows[rowIndex].Cells["Column_Twenty"].Value = Egyukdo[name][2];
                dataGridView_Egyukdo.Rows[rowIndex].Cells["Column_Sixty"].Value = Egyukdo[name][3];
                dataGridView_Egyukdo.Rows[rowIndex].Cells["Column_HundredTwenty"].Value = Egyukdo[name][4];

                if (rowIndex > 99)
                {
                    if (!isShowAll)
                    {
                        break;
                    }
                }
            }
        }

        private void Sequence_TradingVolume(string shortCode)
        {
            int year = DateTime.Now.Year;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;


            string startDay = string.Empty;
            string endDay = endDay = $"{year}{month}{day}";

            if (radioButton1.Checked)
            {
                year -= 1;
            }
            else if (radioButton2.Checked)
            {
                month -= 6;

                if (month <= 0)
                {
                    month += 12;
                    year -= 1;
                }

            }
            else if (radioButton3.Checked)
            {
                month -= 2;

                if (month <= 0)
                {
                    month += 12;
                    year -= 1;
                }
            }
            else if (radioButton4.Checked)
            {
                month -= 1;

                if (month <= 0)
                {
                    month += 12;
                    year -= 1;
                }
            }

            startDay = string.Format("{0}{1:0#}{2:0#}", year, month, day);

            SetQuery(TR.TR_1206);

            //  단축코드
            //  시작일
            //  종료일
            //  데이터 개수 구분       0 : 60개     1 : 전체
            //  데이터 종류 구분       0 : 거래량   1 : 거래대금
            SetInput(shortCode, startDay, endDay, 1, 0);
        }

        private void dataGridView_Recommand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            dataGridView_Recommand.Enabled = false;


            string shortCode = dataGridView_Recommand.Rows[e.RowIndex].Cells[1].Value.ToString();

            forAck.Visible = false;
            ChangeStep(Step.TradingVolume);

            Sequence_TradingVolume(shortCode);
            Request();
        }

        private void DrawChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IsReversed = true;

            int minimum = int.MaxValue;
            int maximum = int.MinValue;
            int volumeMinimum = int.MaxValue;
            int volumeMaximum = int.MinValue;

            Series seriesStock = new Series();
            seriesStock.ChartType = SeriesChartType.Line;
            seriesStock.ChartArea = "ChartArea1";
            seriesStock.Name = "주가";
            seriesStock.SetCustomProperty(c_checkCustomPropertyName, "TRUE");
            seriesStock.YAxisType = AxisType.Secondary;
            seriesStock.Color = Color.Red;

            Series seriesAnt = new Series();
            seriesAnt.ChartType = SeriesChartType.Line;
            seriesAnt.ChartArea = "ChartArea1";
            seriesAnt.Name = "개인";
            seriesAnt.SetCustomProperty(c_checkCustomPropertyName, "TRUE");
            seriesAnt.Color = Color.Black;

            Series seriesForeign = new Series();
            seriesForeign.ChartType = SeriesChartType.Line;
            seriesForeign.ChartArea = "ChartArea1";
            seriesForeign.Name = "외국인";
            seriesForeign.SetCustomProperty(c_checkCustomPropertyName, "TRUE");
            seriesForeign.Color = Color.Green;

            Series seriesGovern = new Series();
            seriesGovern.ChartType = SeriesChartType.Line;
            seriesGovern.ChartArea = "ChartArea1";
            seriesGovern.Name = "기관";
            seriesGovern.SetCustomProperty(c_checkCustomPropertyName, "TRUE");
            seriesGovern.Color = Color.Blue;

            chart1.Series.Add(seriesStock);
            chart1.Series.Add(seriesAnt);
            chart1.Series.Add(seriesForeign);
            chart1.Series.Add(seriesGovern);

            DateTime today = DateTime.Now;


            foreach (string[] data in ReceiveData)
            {
                int year = int.Parse(data[0].Substring(0, 4));
                int month = int.Parse(data[0].Substring(4, 2));
                int day = int.Parse(data[0].Substring(6, 2));

                DateTime dateTime = new DateTime(year, month, day);

                try
                {
                    int dayDiff = (today - dateTime).Days;
                    int stock = int.Parse(data[1]);

                    seriesStock.Points.AddXY(dayDiff, stock);

                    int antVolume = int.Parse(data[13]);
                    int foreignVolume = int.Parse(data[19]);
                    int governVolume = int.Parse(data[25]);

                    seriesAnt.Points.AddXY(dayDiff, int.Parse(data[13]));
                    seriesForeign.Points.AddXY(dayDiff, int.Parse(data[19]));
                    seriesGovern.Points.AddXY(dayDiff, int.Parse(data[25]));

                    if (stock < minimum)
                    {
                        minimum = stock;
                    }
                    if (stock > maximum)
                    {
                        maximum = stock;
                    }

                    if (antVolume < volumeMinimum)
                    {
                        volumeMinimum = antVolume;
                    }
                    if (foreignVolume < volumeMinimum)
                    {
                        volumeMinimum = foreignVolume;
                    }
                    if (governVolume < volumeMinimum)
                    {
                        volumeMinimum = governVolume;
                    }

                    if (antVolume > volumeMaximum)
                    {
                        volumeMaximum = antVolume;
                    }
                    if (foreignVolume > volumeMaximum)
                    {
                        volumeMaximum = foreignVolume;
                    }
                    if (governVolume > volumeMaximum)
                    {
                        volumeMaximum = governVolume;
                    }

                }

                catch
                {
                    continue;
                }

                chart1.ChartAreas[0].AxisY2.Minimum = minimum;
                chart1.ChartAreas[0].AxisY2.Maximum = maximum;

                chart1.ChartAreas[0].AxisY.Minimum = volumeMinimum;
                chart1.ChartAreas[0].AxisY.Maximum = volumeMaximum;

                ChangeStep(Step.No);
            }
        }

        private void button_TradingMoneyVolume_Click(object sender, EventArgs e)
        {
            forAck.Visible = false;

            string shortCode = textBox_ShortCode.Text;
            int howManyDays = 0;
            if (!int.TryParse(textBox_HowManyDays.Text, out howManyDays))
            {
                howManyDays = 10;
            }

            Sequence_TradingMoneyVolume(shortCode, howManyDays);
        }

        private void Sequence_TradingMoneyVolume(string shortCode, int howManyDays)
        {
            #region 거래대금 request  TR_SCHART
            SetQuery(TR.TR_SCHART);

            //  단축코드
            //  그래프종류   1 : 분데이터    D : 일데이터    W : 주데이터    M : 월데이터
            //  시간간격     분이면 1~30     나머지 1
            //  시작일
            //  종료일
            //  조회갯수
            SetInput(shortCode, "D", 1, "00000000", "99999999", howManyDays);

            Request();
            #endregion
        }

        private void dataGridView_Egyukdo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Egyukdo.SelectedRows == null)
            {
                return;
            }
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            textBox_ShortCode.Text = dataGridView_Egyukdo.SelectedRows[0].Cells["Column_ShortCode"].Value.ToString();
        }

    



        private void dataGridView_Step_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_Step.Rows[0].Cells[0].Value == null)
            {
                button_Sequence.Enabled = true;

                return;
            }
            string step = dataGridView_Step.Rows[0].Cells[0].Value.ToString();

            switch (step)
            {
                case "No":
                    button_Sequence.Enabled = true;
                    break;
                case "Egyukdo":
                    Step1();
                    break;
                case "TradingMoneyVolume":
                    Step2();
                    break;
                case "TradingVolume":
                    label14.Text = $"총 {dataGridView_Recommand.RowCount}개";
                    break;

            }
        }


        private void WaitForAck()
        {
            while (!TradingVolumeAck)
            {

            }

            Debug.WriteLine("ACK");
        }


        private async void Step2()
        {
            forAck.Visible = false;

            dataGridView_Recommand.Enabled = false;

            foreach (DataGridViewRow row in dataGridView_Recommand.Rows)
            {
                TradingVolumeAck = false;

                string shortCode = row.Cells[1].Value.ToString();

                int howManyDays = 0;
                if (!int.TryParse(textBox_HowManyDays.Text, out howManyDays))
                {
                    howManyDays = 10;
                }

                recommandIndex = row.Index;

                Sequence_TradingMoneyVolume(shortCode, howManyDays);

                Task ackackack = new Task(() =>
                {
                    WaitForAck();
                });

                ackackack.Start();

                await ackackack;

            }

            ChangeStep(Step.No);

            dataGridView_Recommand.Enabled = true;
        }

        private void Step1()
        {
            dataGridView_Recommand.Enabled = false;

            forAck.Visible = false;

            float min5 = 0, max5 = 0;
            float min20 = 0, max20 = 0;
            float min60 = 0, max60 = 0;
            float min120 = 0, max120 = 0;

            if (!float.TryParse(textBox_min5.Text, out min5))
            {
                min5 = 0;
            }
            if (!float.TryParse(textBox_max5.Text, out max5))
            {
                max5 = 500;
            }
            if (!float.TryParse(textBox_min20.Text, out min20))
            {
                min20 = 0;
            }
            if (!float.TryParse(textBox_max20.Text, out max20))
            {
                max20 = 500;
            }
            if (!float.TryParse(textBox_min60.Text, out min60))
            {
                min60 = 0;
            }
            if (!float.TryParse(textBox_max60.Text, out max60))
            {
                max60 = 500;
            }
            if (!float.TryParse(textBox_min120.Text, out min120))
            {
                min120 = 0;
            }
            if (!float.TryParse(textBox_max120.Text, out max120))
            {
                max120 = 500;
            }

            float tradingMoneyVolume = 0;
            if (!float.TryParse(textBox_TradingMoney1.Text, out tradingMoneyVolume))
            {
                tradingMoneyVolume = 0;
            }

            Sequence_Egyukdo(new PointF(min5, max5), new PointF(min20, max20), new PointF(min60, max60), new PointF(min120, max120), tradingMoneyVolume);
        }

        private void Sequence_Egyukdo(PointF minMax5, PointF minMax20, PointF minMax60, PointF minMax120, float tradingMoneyVolume)
        {
            #region 조건
            this.minMax5 = minMax5;
            this.minMax20 = minMax20;
            this.minMax60 = minMax60;
            this.minMax120 = minMax120;
            this.tradingMoneyVolume = tradingMoneyVolume;
            #endregion

            getWholeStock();
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult result = chart1.HitTest(e.X, e.Y);

            if (result != null && result.Object != null
                && result.Object is LegendItem && e.Button == MouseButtons.Left)
            {
                LegendItem legendItem = (LegendItem)result.Object;

                Series series = chart1.Series[legendItem.SeriesName];

                if (series.GetCustomProperty(c_checkCustomPropertyName).Equals("TRUE"))
                {
                    series.SetCustomProperty(c_checkCustomPropertyName, "FALSE");
                    series.Name = string.Format("{0} {1}", c_uncheckedString, series.Name);
                    series.Color = Color.FromArgb(0, series.Color);
                }
                else if (series.GetCustomProperty(c_checkCustomPropertyName).Equals("FALSE"))
                {
                    series.SetCustomProperty(c_checkCustomPropertyName, "TRUE");
                    string[] tempString = series.Name.Split(' ');
                    series.Name = string.Format("{0} {1}", c_uncheckedString, series.Name);
                    series.Color = ColorTranslator.FromHtml(
                                series.GetCustomProperty("COLOR"));
                }
                else
                {
                    throw new Exception("chart_DetectBatchResult_MouseDown error occurs.");
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                chart1.Visible = !chart1.Visible;
            }
            else if (e.KeyCode == Keys.F11)
            {
                this.Hide();

                formRTGamsi.ShowDialog();

                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axGiExpertControl.UnRequestRTRegAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_UseDIsparity_CheckedChanged(object sender, EventArgs e)
        {
            tableLayoutPanel_DisparityCondition.Enabled = checkBox_UseDisparity.Checked; 
        }

        private void tableLayoutPanel_DisparityCondition_EnabledChanged(object sender, EventArgs e)
        {
            foreach (var control in tableLayoutPanel_DisparityCondition.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    ((TextBox)control).ReadOnly = tableLayoutPanel_DisparityCondition.Enabled;
                }
            }
        }
    }

    
}
