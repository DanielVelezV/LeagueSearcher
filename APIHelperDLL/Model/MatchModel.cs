using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Model
{
    public class MatchModel
    {
        public List<MatchReferenceModel> matches { get; set; }
        public int TotalGames { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }

    public class MatchReferenceModel
    {
        public string Lane { get; set; }
        public long GameID { get; set; }
        public int Champion { get; set; }
        public string PlataformID { get; set; }
        public int Season { get; set; }
        public int Queue { get; set; }
        public string Role { get; set; }
        public long TimeStamp { get; set; }

    }
}
