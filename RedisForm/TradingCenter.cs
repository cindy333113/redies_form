using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisForm
{
    internal class TradingCenter : UseAdapterToGetData
    {
        public override string[] _col { get; set; } = { "bhNo", "cSeq", "rSeq", "tSeq" };
        public override int[] _splitRow { get; set; } = { 6, 9, 9, 9, 8, 1, 1, 1, 1, 2, 2, 1, 16, 3, 6, 6, 3, 1, 1, 1, 1, 12 };
    }
}
