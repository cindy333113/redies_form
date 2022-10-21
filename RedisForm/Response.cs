using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisForm
{
    internal class Response
    {
        public string bhNo { get; set; }
        public string cSeq { get; set; }
        public Content content { get; set; }
        public class Content
        {
            public string bhNo { get; set; }
            public string cSeq { get; set; }
            public string rSeq { get; set; }
            public string tSeq { get; set; }
            public string netSeq { get; set; }
            public string dSeq { get; set; }
            public string mType { get; set; }
            public string eType { get; set; }
            public string oType { get; set; }
            public string tType { get; set; }
            public string bsType { get; set; }
            public string stock { get; set; }
            public string stockName { get; set; }
            public string ordKnd { get; set; }
            public string pCond { get; set; }
            public string tQty { get; set; }
            public string cQty { get; set; }
            public string mQty { get; set; }
            public string uQty { get; set; }
            public string price { get; set; }
            public string currentprice { get; set; }
            public string sales { get; set; }
            public string origSource { get; set; }
            public string statusCode { get; set; }
            public string statusText { get; set; }
            public string iDate { get; set; }
            public string tDate { get; set; }
            public string rTime { get; set; }
        }
    } 
}

