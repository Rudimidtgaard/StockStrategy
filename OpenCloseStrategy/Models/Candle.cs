using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenCloseStrategy.Models.Enums.Enums;

namespace OpenCloseStrategy.Models
{
    public class Candle
    {
        public int Id { get; set; }
        public DateTimeOffset ValidTime { get; set; }

        public decimal OpenPrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }

        public Trend HighTrend { get; set; }
        public Trend LowTrend { get; set; }

        public string? CurrencyCode { get; set; }

    }


}
