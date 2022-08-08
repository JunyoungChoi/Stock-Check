using System.Diagnostics;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxGIEXPERTCONTROLLib;
using GIEXPERTCONTROLLib;

namespace JY.StockChecker
{
    public enum QueryTR
    {
        TR_1206,    // 종목별 기간 거래량 투자자별 고/저가 확인
        TR_1870,    // 이격도
        TR_SCHART,  // 시간별 체결량 및 거래대금
    }

    class GiController
    {
        private bool _isLogin = false;

        private string[,] recvData = null;

        private AxGiExpertControl _giControl;

        private AutoResetEvent dataReceiveEvent = new AutoResetEvent(false);

        public delegate void ReceiveRTDataHandler(string rtType, RtScStock stock);
        public event ReceiveRTDataHandler OnReceiveRTData;

        private QueryTR _curQueryTR;

        private const int RECEIVE_TIMEOUT = 3000;

        private System.Threading.Timer timerReceiveTimeOut;

        enum ColumnSC
        {
            ShortCode = 1,
            CurPrice = 3,
            DayToDayComparison = 4, // 2 = 상승 5 = 하락
            DayToDayPrice = 5,   
            DayToDayRatio = 6,
            TradingVolume = 7,
            TradingMoney = 8,
            StartPrice = 10,
            HighPrice = 11,
            LowPrice = 12,
            HighPriceTime = 14,
            LowPriceTime = 15,
            VolumePower = 24,
        }

       

        public bool IsLogin { get { return _isLogin; } }


        /// <summary>
        /// Class 내부에서 컨트롤 생성 시 에러 발생...
        /// Form 에서 도구로 생성 후 Controller 에 넘겨주는 것으로 우회
        /// </summary>
        /// <param name="giControl"></param>
        public GiController(AxGiExpertControl giControl)
        {
            _giControl = giControl;

            _giControl.ReceiveRTData += _giControl_ReceiveRTData;
            _giControl.ReceiveData += _giControl_ReceiveData;
        }

        private void _giControl_ReceiveData(object sender, _DGiExpertControlEvents_ReceiveDataEvent e)
        {
            Debug.WriteLine("Indi_ReceiveData");

            try
            {
                recvData = (string[,])_giControl.GetMultiBlockData();
            }
            catch (Exception ex)
            {
                recvData = null;
            }
            finally
            {
                dataReceiveEvent.Set();
            }
        }

        /// <summary>
        /// RT 는 아마 SC 만 사용할 듯
        /// </summary>
        /// <param name="rttype"></param>
        private void _giControl_ReceiveRTData(object sender, _DGiExpertControlEvents_ReceiveRTDataEvent e)
        {
            string rtType = e.rttype.ToString();

            switch (rtType)
            {
                case "SC":
                    try
                    {
                        string[] recvData = (string[])_giControl.GetSingleBlockData();

                        string shortCode = recvData[(int)ColumnSC.ShortCode];
                        int curPrice = int.Parse(recvData[(int)ColumnSC.CurPrice]);
                        int dayToDayComparison = int.Parse(recvData[(int)ColumnSC.DayToDayComparison]);
                        int dayToDayPrice = int.Parse(recvData[(int)ColumnSC.DayToDayPrice]);
                        int prevPrice = dayToDayComparison == 2 ? curPrice + dayToDayPrice : curPrice - dayToDayPrice;
                        float dayToDayRatio = dayToDayComparison == 2 ? float.Parse(recvData[(int)ColumnSC.DayToDayRatio]) : -float.Parse(recvData[(int)ColumnSC.DayToDayRatio]);
                        long tradingVolume = long.Parse(recvData[(int)ColumnSC.TradingVolume]);
                        long tradingMoney = long.Parse(recvData[(int)ColumnSC.TradingMoney]);
                        int startPrice = int.Parse(recvData[(int)ColumnSC.StartPrice]);
                        int highPrice = int.Parse(recvData[(int)ColumnSC.HighPrice]);
                        int lowPrice = int.Parse(recvData[(int)ColumnSC.LowPrice]);
                        string highPriceTime = recvData[(int)ColumnSC.HighPriceTime];
                        string lowPriceTime = recvData[(int)ColumnSC.LowPriceTime];
                        float volumePower = float.Parse(recvData[(int)ColumnSC.VolumePower]);

                        //string shortCode = _giControl.GetSingleData((short)ColumnSC.ShortCode).ToString();
                        //int curPrice = (int)_giControl.GetSingleData((short)ColumnSC.CurPrice);
                        //int dayToDayComparison = (int)_giControl.GetSingleData((short)ColumnSC.DayToDayComparison);
                        //int dayToDayPrice = (int)_giControl.GetSingleData((short)ColumnSC.DayToDayPrice);
                        //int prevPrice = dayToDayComparison == 2 ? curPrice + dayToDayPrice : curPrice - dayToDayPrice;
                        //float dayToDayRatio = dayToDayComparison == 2 ? (float)_giControl.GetSingleData((short)ColumnSC.DayToDayRatio) : -(float)_giControl.GetSingleData((short)ColumnSC.DayToDayRatio);
                        //long tradingVolume = (long)_giControl.GetSingleData((short)ColumnSC.TradingVolume);
                        //long tradingMoney = (long)_giControl.GetSingleData((short)ColumnSC.TradingMoney);
                        //int startPrice = (int)_giControl.GetSingleData((short)ColumnSC.StartPrice);
                        //int highPrice = (int)_giControl.GetSingleData((short)ColumnSC.HighPrice);
                        //int lowPrice = (int)_giControl.GetSingleData((short)ColumnSC.LowPrice);
                        //string highPriceTime = _giControl.GetSingleData((short)ColumnSC.HighPriceTime).ToString();
                        //string lowPriceTime = _giControl.GetSingleData((short)ColumnSC.LowPriceTime).ToString();
                        //float volumePower = (float)_giControl.GetSingleData((short)ColumnSC.VolumePower);

                        RtScStock stock = new RtScStock(shortCode, curPrice, prevPrice, tradingMoney, tradingVolume, startPrice, highPrice, lowPrice, highPriceTime, lowPriceTime, volumePower);

                        ReceivedRTData(rtType, stock);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);

                        return;
                    }

                    break;

                default:
                    throw new Exception(string.Format("{0}={1}", nameof(e.rttype), e.rttype));
            }
        }

        public List<string> FilteringStockDisparity(float? min5, float? max5, float? min20, float? max20, float? min60, float? max60, float? min120, float? max120)
        {
            List<string> filteringDatas = new List<string>();

            if (!min5.HasValue) min5 = 0;
            if (!max5.HasValue) max5 = 500;
            if (!min20.HasValue) min20 = 0;
            if (!max20.HasValue) max20 = 500;
            if (!min60.HasValue) min60 = 0;
            if (!max60.HasValue) max60 = 500;
            if (!min120.HasValue) min120 = 0;
            if (!max120.HasValue) max120 = 500;

            string[,] allStocks = GetAllStocksWithDisparity();

            for (int i = 0; i < allStocks.GetLength(0); i++)
            {
                try
                {
                    if (min5 <= float.Parse(allStocks[i, 6]) && max5 >= float.Parse(allStocks[i, 6]) &&
                        min20 <= float.Parse(allStocks[i, 7]) && max20 >= float.Parse(allStocks[i, 7]) &&
                        min60 <= float.Parse(allStocks[i, 8]) && max60 >= float.Parse(allStocks[i, 8]) &&
                        min120 <= float.Parse(allStocks[i, 9]) && max120 >= float.Parse(allStocks[i, 9]))
                    {
                        filteringDatas.Add(allStocks[i, 0]);    // 0은 종목 코드
                        //filteringDatas.Add(allStocks[i, 1]);  // 1은 종목 이름
                    }
                }
                catch
                {
                    continue;
                }
            }

            return filteringDatas;
        }

        private void setQuery(QueryTR tr)
        {
            _giControl.SetQueryName(tr.ToString());
            _curQueryTR = tr;
        }

        public string[,] GetAllStocksWithDisparity()
        {
            string[,] datas = null;

            recvData = null;

            setQuery(QueryTR.TR_1870);

            _giControl.SetSingleData((short)0, "2");
            _giControl.SetSingleData((short)1, "0");
            _giControl.SetSingleData((short)2, "0");
            _giControl.SetSingleData((short)3, "500");

            _giControl.RequestData();

            Debug.WriteLine($"Request Data.");

            timerReceiveTimeOut = new Timer(new TimerCallback(timerTimeOutCallback), null, RECEIVE_TIMEOUT, 1000);

            dataReceiveEvent.WaitOne();

            datas = recvData;

            return datas;
        }

        public string[,] GetData(QueryTR tr, params object[] parameters)
        {
            string[,] datas = null;

            recvData = null;

            setQuery(tr);

            for (int i = 0; i < parameters.Length; i++)
            {
                _giControl.SetSingleData((short)i, parameters[i].ToString());
            }

            _giControl.RequestData();

            Debug.WriteLine($"Request Data.");

            timerReceiveTimeOut = new Timer(new TimerCallback(timerTimeOutCallback), null, RECEIVE_TIMEOUT, 1000);

            dataReceiveEvent.WaitOne();

            datas = recvData;

            return datas;
        }

        private void timerTimeOutCallback(object state)
        {
            Debug.WriteLine("Receive Timeout.");

            dataReceiveEvent.Set();

            timerReceiveTimeOut.Dispose();
        }

        public string GetShortCode(string name)
        {
            return _giControl.GetCodeByName(name).ToString();
        }

        public void StartRTCheck(string shortCode)
        {
            _giControl.RequestRTReg("SC", shortCode);
        }
        
        protected void ReceivedRTData(string rtType, RtScStock stock)
        {
            if (OnReceiveRTData != null)
            {
                OnReceiveRTData(rtType, stock);
            }
        }

        /// <summary>
        /// 매매 사용하지 않기 때문에 인증서 비밀번호 필요하지 않음
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool LogIn(string id, string password, string path)
        {
            if (_isLogin)
            {
                LogOut();

                System.Threading.Thread.Sleep(100);
            }

            try
            {
                _isLogin = _giControl.StartIndi(id, password, "", path);
            }
            catch (Exception ex)
            {
                _isLogin = false;

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return _isLogin;
        }

        public bool LogOut()
        {
            _isLogin = !_giControl.CloseIndi();

            return !_isLogin;
        }
    }
}
