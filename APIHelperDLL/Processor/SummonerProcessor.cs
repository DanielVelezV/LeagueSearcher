using APIHelperDLL.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIHelperDLL.Processor
{
    public static class SummonerProcessor
    {

        public static async Task<SummonerModel> SearchSummoner(string SummonerName)
        {
            string URL = "";

            if (SummonerName != null)
            {
                URL = $"/lol/summoner/v4/summoners/by-name/{SummonerName}?api_key={Token.Key}";
            }

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                SummonerModel model = await response.Content.ReadAsAsync<SummonerModel>();
                return model;
            }
        }
    }
}
