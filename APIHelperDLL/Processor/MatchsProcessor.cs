using APIHelperDLL.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIHelperDLL.Processor
{
    public class MatchsProcessor
    {
        private static MatchModel save;
        public static async Task<MatchModel> GetMatchsBySummoner(string EncriptedAccountID, int EndIndex = 8)
        {
            string URL = $"/lol/match/v4/matchlists/by-account/{EncriptedAccountID}?endIndex={EndIndex}&api_key={Token.Key}";

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                MatchModel data = await response.Content.ReadAsAsync<MatchModel>();
                save = data;
                return data;
            }
        }

        public static async Task<List<MatchParticipantModel>> GetMatchs()
        {
            List<MatchParticipantModel> list = new List<MatchParticipantModel>();
            foreach (var item in save.matches)
            {
                string URL = $"/lol/match/v4/matches/{item.GameID}?api_key={Token.Key}";

                using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
                {

                    MatchParticipantModel data = await response.Content.ReadAsAsync<MatchParticipantModel>();
                    list.Add(data);
                }
            }
            return list;
        }
    }
}
