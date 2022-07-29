using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JY.StockChecker
{
    public class IniStock : JY.Ini
    {
        public IniStock(string filePath) : base(filePath)
        {
            
        }

        public void SaveLastStocks(int count, List<RtScStock> jongmoks)
        {
            IniWriteValue("Stock", "Count", count.ToString());

            string lastDate = IniReadValue("Stock", "LastDate");

            for (int i = 0; i < count; i++)
            {
                IniWriteValue("Name", i.ToString(), jongmoks[i].Name);
                IniWriteValue("ShortCode", i.ToString(), jongmoks[i].ShortCode);
                IniWriteValue("Price", i.ToString(), jongmoks[i].Price);
                IniWriteValue("Count", i.ToString(), jongmoks[i].Count.ToString());
                IniWriteValue("LastPrice", i.ToString(), jongmoks[i].LastPrice);
            }

            IniWriteValue("Stock", "LastDate", DateTime.Now.ToString("MMdd_HHmm"));
        }

        public List<RtScStock> LoadLastJongmoks()
        {
            List<RtScStock> stocks = new List<RtScStock>();

            int count = 0;

            if (!int.TryParse(IniReadValue("Stock", "Count"), out count))
            {
                return stocks;
            }

            for (int i = 0; i < count; i++)
            {
                string name = IniReadValue("Name", i.ToString());
                string shortCode = IniReadValue("ShortCode", i.ToString());
                string Price = IniReadValue("Price", i.ToString());
                string lastPrice = IniReadValue("LastPrice", i.ToString());
                int tempLastPrice = 0;
                int priceCount = 0;

                int.TryParse(IniReadValue("Count", i.ToString()), out priceCount);

                int.TryParse(lastPrice, out tempLastPrice);

                stocks.Add(new Stock(name, shortCode, Price, priceCount, tempLastPrice.ToString()));
            }

            return stocks;
        }
    }
}
