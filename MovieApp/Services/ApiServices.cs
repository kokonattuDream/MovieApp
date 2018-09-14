using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Models;
using Newtonsoft.Json;

namespace MovieApp.Services
{
    public class ApiServices
    {
        string nowPlayingMoviesUrl = "http://colosseum.somee.com/api/NowPlayingMovies";

        public async Task<List<NowPlayingMovie>> GetNowPlayingMovies()
        {
            var client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, nowPlayingMoviesUrl);

            requestMessage.Headers.Add("ApiKey", "e0d9b4e1-0310-4f03-978b-3728d1c77b42");

            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<NowPlayingMovie>>(movieResponse);
        }
    }
}
