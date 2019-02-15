using APIHelperDLL.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIHelperDLL.Processor
{
    public static class SpectatorProcessor
    {
        
        public static async Task<SpectatorModel> SpectateSummoner(string SummonerName)
        {
            string URL = "";

            SummonerModel data = await SummonerProcessor.SearchSummoner(SummonerName);

            if (SummonerName != null)
            {
                URL = $"/lol/spectator/v4/active-games/by-summoner/{data.ID}?api_key={Token.Key}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                SpectatorModel match = await response.Content.ReadAsAsync<SpectatorModel>();
                return match;
            }

        }

        public static async Task<SpectatorModel> SpectateSummonerData(string ID)
        {
            string URL = "";

            if (ID != null)
            {
                URL = $"/lol/spectator/v4/active-games/by-summoner/{ID}?api_key={Token.Key}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                SpectatorModel match = await response.Content.ReadAsAsync<SpectatorModel>();
                return match;
            }

        }

    }
}
