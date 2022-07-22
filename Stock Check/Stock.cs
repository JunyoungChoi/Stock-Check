using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JY.Stock
{
    public class Stock
    {
        private int _curPrice = 0;  // 현재가
        private int _prePrice = 0;  // 전일가
        private string _shortCode = string.Empty;   // 종목코드
        private long _tradeMoney = 0L;  // 누적거래대금
        private long _tradeVolume = 0L; // 누적거래량

        private int _startPrice = 0;    // 시가
        private int _highPrice = 0;     // 고가
        private int _losPrice = 0;      // 저가

        private string _highPriceTime = string.Empty;   // 고가 시간
        private string _lowPriceTime = string.Empty;    // 저가 시간

        private float _volumePower = 0f;    // 체결강도

        public string Name { get; set; }
        public string ShortCode { get { return _shortCode; } }
        public int PrevPrice { get { return _prePrice; } }
        public int CurPrice { get { return _curPrice; } }
        public int Count = 0;

        public double AverageTradePrice { get { return _tradeMoney / (double)_tradeVolume; } }

        
    }

}
