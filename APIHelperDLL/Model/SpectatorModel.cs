using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Model
{
    public class SpectatorModel
    {
        public string gameMode { get; set; }
        public long GameID { get; set; }
        public string gameType { get; set; }
        public List<SpectParticipantModel> participants { get; set; }
        public long GameLength { get; set; }
        public List<BannedChamps> BannedChampions { get; set; }
    }

    public class BannedChamps
    {
        public int PickTurn { get; set; }
        public long ChampionID { get; set; }
        public long TeamID { get; set; }

    }
}
