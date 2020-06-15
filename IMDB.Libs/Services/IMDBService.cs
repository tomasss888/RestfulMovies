using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDB.Libs.Services
{
    public static class IMDBServices
    {
        private static string xRapid_Host = "imdb8.p.rapidapi.com";
        private static string xRapid_Key = "3f5bc5a363msh84ab41cb5de7e9bp1d5ed3jsn0d046b228b2f";

        /*
         Will we need further process of received responses and unique methods with uniq actions,
         or do we make a single universal request?
        */

        public static async Task<string> getTop250()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", xRapid_Host);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", xRapid_Key);

                var url = new Uri("https://imdb8.p.rapidapi.com/title/get-top-rated-movies");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                    json = await content.ReadAsStringAsync();

                return json.ToString();
            }
        }

        public static async Task<string> getSimilarMovies(string mID)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", xRapid_Host);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", xRapid_Key);

                var url = new Uri($"https://imdb8.p.rapidapi.com/title/get-more-like-this?currentCountry=US&purchaseCountry=US&tconst={mID}");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                    json = await content.ReadAsStringAsync();

                return json.ToString();
            }
        }
    }
}
