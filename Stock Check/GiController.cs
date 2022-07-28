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
    class GiController
    {
        private bool _isLogin = false;

        private string[,] recvData = null;

        private AxGiExpertControl _giControl;

        private AutoResetEvent dataReceiveEvent = new AutoResetEvent(false);

        public delegate void ReceiveRTDataHandler(string rtType, Stock stock);
        public event ReceiveRTDataHandler OnReceiveRTData;

        private QueryTR _curQueryTR;

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

        public enum QueryTR
        {
            TR_1206,    // 종목별 기간 거래량 투자자별 고/저가 확인
            TR_1870,    // 이격도
            TR_SCHART,  // 시간별 체결량 및 거래대금
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

                        Stock stock = new Stock(shortCode, curPrice, prevPrice, tradingMoney, tradingVolume, startPrice, highPrice, lowPrice, highPriceTime, lowPriceTime, volumePower);

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

        private void setQuery(QueryTR tr)
        {
            _giControl.SetQueryName(tr.ToString());
            _curQueryTR = tr;
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

            dataReceiveEvent.WaitOne();

            datas = recvData;

            return datas;
        }

        public string GetShortCode(string name)
        {
            return _giControl.GetCodeByName(name).ToString();
        }

        public void StartRTCheck(string shortCode)
        {
            _giControl.RequestRTReg("SC", shortCode);
        }
        
        protected void ReceivedRTData(string rtType, Stock stock)
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
