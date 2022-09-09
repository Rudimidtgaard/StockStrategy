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
            LowLower = 4
        }
    }
}
