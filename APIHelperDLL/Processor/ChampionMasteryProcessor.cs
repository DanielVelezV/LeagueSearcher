using APIHelperDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Processor
{
    public class ChampionMasteryProcessor
    {
        public static async Task<List<ChampionMasteryModel>> GetChampionsMastery(string EncriptedSummonerID)
        {
            string URL = $"/lol/champion-mastery/v4/champion-masteries/by-summoner/{EncriptedSummonerID}?api_key={Token.Key}";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                List<ChampionMasteryModel> data = await response.Content.ReadAsAsync<List<ChampionMasteryModel>>();
                return data;
            }
        }
    }
}
