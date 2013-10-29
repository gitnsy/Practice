using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practice.Models
{
    public class SearchResult
    {
        public List<Tuple<string, List<object>>> Result { get; set; }
        public Dictionary<int, decimal> SumDic { get; set; }
    }
}