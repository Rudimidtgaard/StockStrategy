using OpenCloseStrategy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenCloseStrategy.Models.Enums.Enums;

namespace OpenCloseStrategy.Service
{
    public static class Trade
    {
        public static List<Candle> GetCandlesByDate(DateTime fromDateTime, DateTime toDateTime)
        {
            List<Candle> candles = new List<Candle>();
            List<Candle> returnCandles = new List<Candle>();

            candles = Data.DataHelper.GetCandles();

            foreach (var candle in candles)
            {
                if (candle.ValidTime.UtcDateTime >= fromDateTime && candle.ValidTime.UtcDateTime <= toDateTime)
                {
                    returnCandles.Add(candle);
                }
            }
            return returnCandles;
        }

        public static OpenCloseTradingSession GetTradingSession(DateOnly date, SessionTimeOfDay sessionTimeOfDay)
        {
            var tradeingSesseion = new OpenCloseTradingSession();

            tradeingSesseion.SessionDate = date;
            tradeingSesseion.TimeOfDay = sessionTimeOfDay;

            tradeingSesseion.Candles = new List<Candle>();
            DateTime requestDateTimeFrom = new DateTime();
            DateTime requestDateTimeTo = new DateTime();
            switch (sessionTimeOfDay)
            {
                case SessionTimeOfDay.Morning:
                    TimeOnly morningTimeFrom = new TimeOnly(09, 00);
                    TimeOnly morningTimeTo = new TimeOnly(09, 15);

                    requestDateTimeFrom = date.ToDateTime(morningTimeFrom);
                    requestDateTimeTo = date.ToDateTime(morningTimeTo);

                    tradeingSesseion.Candles = Trade.GetCandlesByDate(requestDateTimeFrom, requestDateTimeTo);
                    break;
                case SessionTimeOfDay.Afternoon:
                    TimeOnly afternoonTimeFrom = new TimeOnly(15, 00);
                    TimeOnly afternoonTimeTo = new TimeOnly(15, 15);

                    requestDateTimeFrom = date.ToDateTime(afternoonTimeFrom);
                    requestDateTimeTo = date.ToDateTime(afternoonTimeTo);

                    tradeingSesseion.Candles = Trade.GetCandlesByDate(requestDateTimeFrom, requestDateTimeTo);
                    break;
            }

            var startTrend = GetSessionTrend(tradeingSesseion.Candles);

            tradeingSesseion.StartTrend = startTrend.trend;
            tradeingSesseion.StartTrendDiscovered = startTrend.numberOfCandlesForTrend;

            // Not the best solution, basically just geting all candles, minus the amount of candles from StartTrendDiscovered
            //Need to find the opposite of StartTrend. Not the new trend :-/
            var shiftTrend = GetSessionTrend(tradeingSesseion.Candles.GetRange(tradeingSesseion.StartTrendDiscovered, (tradeingSesseion.Candles.Count() - tradeingSesseion.StartTrendDiscovered)));

            tradeingSesseion.ShiftTrend = shiftTrend.trend;
            tradeingSesseion.ShiftTrendDiscovered = shiftTrend.numberOfCandlesForTrend;




            return tradeingSesseion;
        }

        private static (int numberOfCandlesForTrend, SessionTrend trend) GetSessionTrend(List<Candle> candles)
        {
            for (int i = 0; i < candles.Count(); i++)
            {
                if (candles[i].HighTrend == Trend.HighHigher && candles[i].LowTrend == Trend.LowHigher)
                {                
                    return (i, SessionTrend.GoingUp);
                }
                else if (candles[i].HighTrend == Trend.HighLower && candles[i].LowTrend == Trend.LowLower)
                {
                    return (i, SessionTrend.GoingDown);
                }
            }

            return (0, SessionTrend.Neutral);
        }



    }
}
