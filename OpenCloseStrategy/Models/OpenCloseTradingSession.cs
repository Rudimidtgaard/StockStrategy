using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenCloseStrategy.Models.Enums.Enums;

namespace OpenCloseStrategy.Models
{
    public class OpenCloseTradingSession : TradingSessionBase
    {
        public override int Id { get; set; }
        public override DateOnly SessionDate { get; set; }
        public override SessionTimeOfDay TimeOfDay { get; set; }

        public SessionTrend StartTrend { get; set; } = SessionTrend.Neutral;

        public DateTimeOffset TrendShift { get; set; }

        public override List<Candle> Candles { get; set; }


        public OpenCloseTradingSession()
        {
            Candles = new List<Candle>();
        }

    }
}
