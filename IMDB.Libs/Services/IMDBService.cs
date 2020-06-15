using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IMDB.Libs.Services
{
    public static class IMDBServices
    {
        public static async Task<string> getTop250()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "imdb8.p.rapidapi.com");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "3f5bc5a363msh84ab41cb5de7e9bp1d5ed3jsn0d046b228b2f");

                var url = new Uri("https://imdb8.p.rapidapi.com/title/get-top-rated-movies");

                var response = await client.GetAsync(url);

                string json;

                using (var content = response.Content)
                    json = await content.ReadAsStringAsync();

                return json.ToString();
            }
        }
    }
}
