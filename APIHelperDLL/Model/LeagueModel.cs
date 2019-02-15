using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Model
{
    public class LeagueModel
    {
        public string QueueType { get; set; }
        public string SummonerName { get; set; }
        public bool HotStreak { get; set; }
        public MiniSeriesDT MiniSeries { get; set; }
        public int Wins { get; set; }
        public bool Veteran { get; set; }
        public int Losses { get; set; }
        public string Rank { get; set; }
        public string LeagueID { get; set; }
        public bool Inactive { get; set; }
        public bool FreshBlood { get; set; }
        public string LeagueName { get; set; }
        public string Position { get; set; }
        public string Tier { get; set; }
        public string SummonerID { get; set; }
        public int LeaguePoints { get; set; }

    }

    public class MiniSeriesDT
    {
        public string Progress { get; set; }
        public int Losses { get; set; }
        public int Target { get; set; }
        public int Wins { get; set; }
    }
}
