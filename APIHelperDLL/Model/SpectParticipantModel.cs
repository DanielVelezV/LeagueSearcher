using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Model
{
    public class SpectParticipantModel
    {
        public int profileIconId { get; set; } // Icono del invocador
        public long ChampionID { get; set; } //ID del campeon que esta jugando
        public string summonerName { get; set; } // Nombre del invocador
        public long spell2Id { get; set; } //Spell 2 del invocador
        public long spell1Id { get; set; } //Spell 1 del invocador
        public long teamId { get; set; } //Id del equipo del invocador
        public string summonerID { get; set; } //EncriptedSummonerID
    }
}
