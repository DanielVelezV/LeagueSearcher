using System.Collections.Generic;

namespace APIHelperDLL.Model
{
    public class MatchParticipantModel
    {
        public List<ParticipantsDTO> participants { get; set; }
        public List<ParticipantIdentityDTO> participantIdentities { get; set; }
    }

    public class ParticipantIdentityDTO
    {
        public playerDTO player { get; set; }
        public int ParticipantID { get; set; }
    }

    public class playerDTO
    {
        public string SummonerName { get; set; }
        public string MatchHistoryUri { get; set; }

    }

    public class ParticipantsDTO
    {
        public ParticipantStatsDto stats { get; set; }
        public int Spell1ID { get; set; }
        public int Spell2ID { get; set; }
    }

    public class ParticipantStatsDto
    {
        public int ParticipantID { get; set; }
        public bool Win { get; set; }

        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }

        public int Deaths { get; set; }
        public int Assist { get; set; }
        public int Kills { get; set; }

    }
}
