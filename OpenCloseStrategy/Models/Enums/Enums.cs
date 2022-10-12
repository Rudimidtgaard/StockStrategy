using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCloseStrategy.Models.Enums
{
    public class Enums
    {
        public enum Trend : byte
        {
            Unknown = 0,
            HighHigher = 1,
            HighLower = 2,
            LowHigher = 3,
            LowLower = 4,
            Neutral = 5
        }

        public enum SessionTrend : byte 
        {
            Neutral = 0,
            GoingUp = 1,
            GoingDown = 2
        }

        public enum SessionTimeOfDay : byte
        {
            Morning = 1,
            Afternoon = 2
        }
    }
}
