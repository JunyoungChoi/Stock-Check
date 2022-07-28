using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JY.StockChecker
{
    /// <summary>
    /// SC type
    /// </summary>
    public class Stock
    {
        //private int _curPrice = 0;  // 현재가
        //private int _prePrice = 0;  // 전일가
        //private string _shortCode = string.Empty;   // 종목코드
        //private long _tradeMoney = 0L;  // 누적거래대금
        //private long _tradeVolume = 0L; // 누적거래량

        //private int _startPrice = 0;    // 시가
        //private int _highPrice = 0;     // 고가
        //private int _losPrice = 0;      // 저가

        //private string _highPriceTime = string.Empty;   // 고가 시간
        //private string _lowPriceTime = string.Empty;    // 저가 시간

        //private float _volumePower = 0f;    // 체결강도

        //private int _count = 0;     // 주식 알림을 위한

        public string Name { get; set; }    // 주식 이름
        public int CurPrice { get; private set; }   // 현재가
        public int PrevPrice { get; private set; }  // 전일가
        public string ShortCode { get; private set; }   // 종목코드
        public long TradeMoney { get; private set; }    // 거래대금
        public long TradeVolume { get; private set; }   // 거래량
        public int StartPrice { get; private set; }     // 시가
        public int HighPrice { get; private set; }      // 고가
        public int LowPrice { get; private set; }       // 저가
        public string HighPriceTime { get; private set; }   // 고가 도달 시간
        public string LowPriceTime { get; private set; }    // 저가 도달 시간
        public float VolumePower { get; private set; }      // 체결 강도
        public int Unit { get; set; }       // 주가 알림을 하기 위한 단위의 갯수

        public double AverageTradePrice { get { return TradeMoney / (double)TradeVolume; } }  // 평균 체결 가격

     
        public Stock(string shortCode, int curPrice, int prevPrice, long tradeMoney, long tradeVolume, int startPrice, int highPrice, int lowPrice, string highPriceTime, string lowPriceTime, float volumePower)
        {
            this.CurPrice = CurPrice;
            this.PrevPrice = prevPrice;
            this.ShortCode = shortCode;
            this.TradeMoney = tradeMoney;
            this.TradeVolume = tradeVolume;
            this.StartPrice = startPrice;
            this.HighPrice = highPrice;
            this.LowPrice = lowPrice;
            this.HighPriceTime = highPriceTime;
            this.LowPriceTime = lowPriceTime;
            this.VolumePower = volumePower;
        }
    }

}
