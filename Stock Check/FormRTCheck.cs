using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms.DataVisualization.Charting;

namespace JY.Stock
{
    public partial class FormRTCheck : Form
    {
        // int a =3 3
        private readonly float percentage = 0.015f;

        private CheckBox forStatus;

        DataTable gamsiList;

        Dictionary<string, int> checkPrice;

        public bool IsGamsing { get { return forStatus.Checked; } set { forStatus.Checked = value; } }

        AxGIEXPERTCONTROLLib.AxGiExpertControl indi;

        Task taskUpdatePrice;
        Queue<string> queueUpdatePrice;

        Task taskSendMail;
        Queue<MailData> queueSendMail;

        IniStock ini = new IniStock(System.IO.Path.Combine(Application.StartupPath, "Setting.ini"));


        public FormRTCheck(AxGIEXPERTCONTROLLib.AxGiExpertControl axGiExpertControl)
        {

            InitializeComponent();

            forStatus = new CheckBox();

            forStatus.Checked = false;

            forStatus.CheckedChanged += ForStatus_CheckedChanged;

            indi = axGiExpertControl;
            indi.ReceiveRTData += Indi_ReceiveRTData1;

            InitGamsiList();

            LoadLastJongmoks();
        }

        public void FormRTGamsi_StopGamsi()
        {
            IsGamsing = false;
        }

        private void ForStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (forStatus.Checked)
            {
                button_AllStart.Text = "Stop";
                label_Status.Text = "Gamsi";
            }
            else
            {
                button_AllStart.Text = "All Start";
                label_Status.Text = "Non-Gamsi";
            }
        }

        private void LoadLastJongmoks()
        {
            List<Stock> jongmoks = ini.LoadLastJongmoks();

            foreach (Stock jongmok in jongmoks)
            {
                gamsiList.Rows.Add(jongmok.Name, jongmok.ShortCode, jongmok.Price, 0, jongmok.LastPrice);

                checkPrice[jongmok.ShortCode] = jongmok.Count;
            }
        }

        private void SaveLastJongmoks()
        {
            List<Stock> jongmoks = new List<Stock>();

            foreach (DataRow dataRow in gamsiList.Rows)
            {
                jongmoks.Add(new Stock(dataRow["Name"].ToString(), dataRow["ShortCode"].ToString(), dataRow["My Price"].ToString(), checkPrice[dataRow["ShortCode"].ToString()], dataRow["Cur Price"].ToString()));
            }

            ini.SaveLastStocks(gamsiList.Rows.Count, jongmoks);
        }

        private void Indi_ReceiveRTData1(object sender, AxGIEXPERTCONTROLLib._DGiExpertControlEvents_ReceiveRTDataEvent e)
        {
            string shortCode = indi.GetSingleData(1).ToString();
            string price = indi.GetSingleData(3).ToString();

            CheckPrice(shortCode, int.Parse(price));
            queueUpdatePrice.Enqueue(string.Format("{0}|{1}", shortCode, price));

            System.Diagnostics.Debug.WriteLine(string.Format($"{shortCode} : {price}"));
            toolStripStatusLabel1.Text = string.Format($"[{DateTime.Now.ToString("HH:mm:ss")}] : {shortCode} : {price}");
        }

        private void UpdatePrice(string shortCode, string price)
        {
            foreach (DataRow row in gamsiList.Rows)
            {
                if (row["ShortCode"].ToString().Equals(shortCode))
                {
                    row["Cur Price"] = price;
                }
            }

            dataGridView_GamsiList.Invoke((MethodInvoker)delegate
            {
                dataGridView_GamsiList.DataSource = gamsiList;
            });
        }

        private void FormRTGamsi_Load(object sender, EventArgs e)
        {
            if (IsGamsing)
            {
                button_AllStart.Text = "Stop";
            }
            else
            {
                button_AllStart.Text = "All Start";
            }

            queueUpdatePrice = new Queue<string>();

            if (taskUpdatePrice == null || taskUpdatePrice.Status != TaskStatus.Running)
            {
                taskUpdatePrice = new Task(() =>
                {
                    while (true)
                    {
                        if (queueUpdatePrice.Count > 0)
                        {
                            string data = queueUpdatePrice.Dequeue();

                            string[] temp = data.Split('|');

                            UpdatePrice(temp[0], temp[1]);
                        }
                        System.Threading.Thread.Sleep(10);
                    }
                });

                taskUpdatePrice.Start();
            }

            queueSendMail = new Queue<MailData>();

            if (taskSendMail == null || taskSendMail.Status != TaskStatus.Running)
            {
                taskSendMail = new Task(() =>
                {
                    while (true)
                    {
                        if (queueSendMail.Count > 0)
                        {
                            MailData mailData = queueSendMail.Dequeue();

                            SendEmail(mailData.Name, mailData.CurPrice, mailData.MyPrice, mailData.Ratio);
                        }

                        System.Threading.Thread.Sleep(20);
                    }
                });

                taskSendMail.Start();
            }
        }

        private void button_Gamsi_Click(object sender, EventArgs e)
        {
            if (IsGamsing)
            {
                button_Gamsi.Text = "Start";
                label_Status.Text = "Non-Gamsi";
            }
            else
            {
                button_Gamsi.Text = "Stop";
                label_Status.Text = "Gamsi";
            }

            IsGamsing = !IsGamsing;
        }

        private void InitGamsiList()
        {
            gamsiList = new DataTable();

            gamsiList.Columns.Add("Name", typeof(string));
            gamsiList.Columns.Add("ShortCode", typeof(string));
            gamsiList.Columns.Add("My Price", typeof(int));
            gamsiList.Columns.Add("Cur Price", typeof(int));
            gamsiList.Columns.Add("Last Price", typeof(int));

            dataGridView_GamsiList.DataSource = gamsiList;
            checkPrice = new Dictionary<string, int>();
        }

        private void AddGamsiList(string name, string shortCode, int price)
        {
            foreach (DataRow dataRow in gamsiList.Rows)
            {
                if (dataRow["Name"].Equals(name) || dataRow["ShortCode"].Equals(shortCode))
                {
                    return;
                }
            }

            gamsiList.Rows.Add(name, shortCode, price, 0, 0);

            dataGridView_GamsiList.DataSource = gamsiList;

            checkPrice[shortCode] = 0;

            indi.RequestRTReg("SC", shortCode);

            IsGamsing = true;

            button_AllStart.Text = "Stop";

            fromAddDelete = true;
        }

        private void DeleteGamsiList(string name, string shortCode)
        {
            foreach (DataRow dataRow in gamsiList.Rows)
            {
                if (dataRow["Name"].Equals(name) && dataRow["ShortCode"].Equals(shortCode))
                {
                    gamsiList.Rows.Remove(dataRow);

                    break;
                }
            }

            indi.UnRequestRTReg("SC", shortCode);

            checkPrice.Remove(shortCode);

            dataGridView_GamsiList.DataSource = gamsiList;

            fromAddDelete = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox_Name.Text;
            string shortCode = textBox_ShortCode.Text;
            string price = textBox_Price.Text;

            int myPrice = 0;

            if (!int.TryParse(price,out myPrice))
            {
                MessageBox.Show("Price error");
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(shortCode))
            {
                MessageBox.Show("Name or Shortcode error");
                return;
            }

            AddGamsiList(name, shortCode, myPrice);
        }

        private void FormRTGamsi_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsGamsing = false;

            indi.UnRequestRTRegAll();

            SaveLastJongmoks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox_Name.Text;
            string shortCode = textBox_ShortCode.Text;
            string price = textBox_Price.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(shortCode))
            {
                MessageBox.Show("Name or Shortcode error");
                return;
            }

            DeleteGamsiList(name, shortCode);
        }

        bool fromAddDelete = false;

        private void dataGridView_GamsiList_SelectionChanged(object sender, EventArgs e)
        {
            if (fromAddDelete)
            {
                fromAddDelete = false;

                return;
            }

            int rowIndex = dataGridView_GamsiList.CurrentRow.Index;

            if (rowIndex < 0)
            {
                return;
            }

            textBox_Name.Text = gamsiList.Rows[rowIndex]["Name"].ToString();
            textBox_ShortCode.Text = gamsiList.Rows[rowIndex]["ShortCode"].ToString();
            textBox_Price.Text = gamsiList.Rows[rowIndex]["My Price"].ToString();
        }

        private void CheckPrice(string shortCode, int price)
        {
            int myPrice = 0;
            string name = string.Empty;

            foreach (DataRow dataRow in gamsiList.Rows)
            {
                if (dataRow["ShortCode"].Equals(shortCode))
                {
                    name = dataRow["Name"].ToString();

                    if (!int.TryParse(dataRow["My Price"].ToString(), out myPrice))
                    {
                        return;
                    }
                }
            }

            if (myPrice <= 0)
            {
                return;
            }

            int level = 0;
            if (!checkPrice.TryGetValue(shortCode, out level))
            {
                checkPrice[shortCode] = 0;
            }

            float centerValue = 1.0f + level * percentage;

            float upValue = centerValue + percentage;
            float downValue = centerValue - percentage;

            float ratio = ((float)price / (float)myPrice);

            if (ratio <= downValue)
            {
                checkPrice[shortCode] -= (int)((centerValue - ratio) / percentage);
            }

            else if (upValue <= ratio)
            {
                checkPrice[shortCode] += (int)((ratio - centerValue) / percentage);
            }

            else
            {
                return;
            }

            queueSendMail.Enqueue(new MailData(name, price, myPrice, ratio));
        }

        public void SendEmail(string name, int curPrice, int myPrice, float ratio)
        {
            throw new NotImplementedException("개인 정보로 인한 삭제, 공용 사용 가능하도록 변경 진행 예정");
        }

        private void button_AllSet_Click(object sender, EventArgs e)
        {
            string buttonText = ((Button)sender).Text;

            switch (buttonText.ToLower())
            {
                case "all start":
                    foreach (DataRow dataRow in gamsiList.Rows)
                    {
                        indi.RequestRTReg("SC", dataRow["ShortCode"].ToString());
                    }

                    ((Button)sender).Text = "Stop";

                    IsGamsing = true;

                    toolStripStatusLabel1.Text = string.Format($"[{DateTime.Now.ToString("HH:mm:ss")}] Started.");
                    break;
                case "stop":
                    indi.UnRequestRTRegAll();

                    ((Button)sender).Text = "All Start";

                    IsGamsing = false;

                    toolStripStatusLabel1.Text = string.Format($"[{DateTime.Now.ToString("HH:mm:ss")}] Stopped.");
                    break;
            }
        }

        private void dataGridView_GamsiList_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo info = dataGridView_GamsiList.HitTest(e.X, e.Y);

            if (info.Type == DataGridViewHitTestType.Cell)
            {
                int rowIndex = info.RowIndex;

                if (rowIndex < 0)
                {
                    return;
                }

                textBox_Name.Text = gamsiList.Rows[rowIndex]["Name"].ToString();
                textBox_ShortCode.Text = gamsiList.Rows[rowIndex]["ShortCode"].ToString();
                textBox_Price.Text = gamsiList.Rows[rowIndex]["My Price"].ToString();
            }
        }

        private void button_ChangePrice_Click(object sender, EventArgs e)
        {
            float myPrice = 0;
            string shortCode = textBox_ShortCode.Text;

            if (!float.TryParse(textBox_Price.Text, out myPrice))
            {
                return;
            }

            foreach (DataRow row in gamsiList.Rows)
            {
                if (row["ShortCode"].ToString().Equals(shortCode))
                {
                    row["My Price"] = myPrice.ToString();
                }
            }
        }
    }

    class MailData
    {
        public string Name;
        public int CurPrice;
        public int MyPrice;
        public float Ratio;

        public MailData(string name, int curPrice, int myPrice, float ratio)
        {
            Name = name;
            CurPrice = curPrice;
            MyPrice = myPrice;
            Ratio = ratio;
        }
    }
}
