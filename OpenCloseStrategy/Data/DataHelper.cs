using OpenCloseStrategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenCloseStrategy.Models.Enums.Enums;

namespace OpenCloseStrategy.Data
{
    public class DataHelper
    {

        public static List<Candle> GetCandles()
        {
            //Get all candles from DB. For now the data is hardcoded. 

            var allCandles = new List<Candle>();
            int counter = 0;
            string filePath = File.Exists(@"C:\GitPrivate\StockStrategy\CandleData.csv") ? @"C:\GitPrivate\StockStrategy\CandleData.csv" : @"C:\Git\StockStrategy\CandleData.csv";

            foreach (string line in System.IO.File.ReadLines(filePath))
            {
                counter++;

                // First line = header
                if (counter == 1)
                    continue;

                Candle candle = new Candle();

                var lineArray = line.Split(',');

                candle.ValidTime = UnixTimeStampToDateTime(Convert.ToDouble(lineArray[0]));
                candle.OpenPrice = Convert.ToDecimal(lineArray[1], new System.Globalization.CultureInfo("en-US"));
                candle.HighPrice = Convert.ToDecimal(lineArray[2], new System.Globalization.CultureInfo("en-US"));
                candle.LowPrice = Convert.ToDecimal(lineArray[3], new System.Globalization.CultureInfo("en-US"));
                candle.ClosePrice = Convert.ToDecimal(lineArray[4], new System.Globalization.CultureInfo("en-US"));

                candle.HighTrend = GetTrend(candle.HighPrice, allCandles?.LastOrDefault()?.HighPrice, "High");
                candle.LowTrend = GetTrend(candle.LowPrice, allCandles?.LastOrDefault()?.LowPrice, "Low");

                allCandles.Add(candle);
            }

            return allCandles;
        }

        // https://stackoverflow.com/questions/249760/how-can-i-convert-a-unix-timestamp-to-datetime-and-vice-versa
        private static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        private static Trend GetTrend(decimal? currentPrice, decimal? lastPrice, string type)
        {
            // What should be returned if currentprice == lastPrice ?

            if (type == "High")
            {
                if (currentPrice > lastPrice)
                    return Trend.HighHigher;
                if (currentPrice < lastPrice)
                    return Trend.HighLower;
                if (currentPrice == lastPrice)
                    return Trend.Neutral;
            }
            else if (type == "Low")
            {
                if (currentPrice > lastPrice)
                    return Trend.LowHigher;
                if (currentPrice < lastPrice)
                    return Trend.LowLower;
                if (currentPrice == lastPrice)
                    return Trend.Neutral;
            }

            return Trend.Unknown;
        }


    }
}
