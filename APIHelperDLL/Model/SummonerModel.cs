using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Model
{
    public class SummonerModel
    {
        public string ID { get; set; } //EncriptedSummonerId
        public string Name { get; set; } //Nombre de la cuenta
        public string PUUID { get; set; } // EncriptedPUUID (78 caracteres de Largo)
        public long SummonerLevel { get; set; } //Nivel de invocador
        public string AccountID { get; set; } //EncriptedAccountID
        public int ProfileIconID { get; set; } //Icono del Invocador
    }
}
