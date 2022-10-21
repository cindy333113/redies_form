using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisForm
{
    internal class Request
    {
        public string bhNo { get; set; }
        public string cSeq { get; set; }
        public Content content { get; set; }
        public class Content
        {
            public string eType { get; set; }
            public string tType { get; set; }
            public string stock { get; set; }
        }
    }

}
