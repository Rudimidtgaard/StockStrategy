using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCloseStrategy.Models
{
    public class TradingSession
    {
        public int Id { get; set; }
        public DateOnly SessionDate { get; set; }

        public List<Candle> Candles { get; set; }


        public TradingSession()
        {
            Candles = new List<Candle>();
        }

    }
}
