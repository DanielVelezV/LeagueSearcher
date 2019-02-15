using APIHelperDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIHelperDLL.Processor
{
    public class LeagueProcessor
    {
        public static async Task<List<LeagueModel>> GetLeague(string EncriptedSummonerID)
        {
            string URL = $"/lol/league/v4/positions/by-summoner/{EncriptedSummonerID}?api_key={Token.Key}";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                
                List<LeagueModel> data = await response.Content.ReadAsAsync<List<LeagueModel>>();
                return data;
            }

        }
    }
}
