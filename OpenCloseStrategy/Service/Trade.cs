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
                    requestDateTimeTo = date.ToDateTime(morningTimeFrom);

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

            foreach(var candle in tradeingSesseion.Candles)
            {
                if(candle.HighTrend == Trend.HighHigher && candle.LowTrend == Trend.LowHigher)
                {
                    tradeingSesseion.StartTrend = SessionTrend.GoingUp;
                    break;
                }
                if(candle.HighTrend == Trend.HighLower && candle.LowTrend == Trend.LowLower)
                {
                    tradeingSesseion.StartTrend = SessionTrend.GoingDown;
                    break;
                }

                tradeingSesseion.StartTrend = SessionTrend.Neutral;
            }

            //
            //tradeingSesseion.TrendShift;

            return tradeingSesseion;
        }
    }
}
