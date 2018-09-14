using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace MovieApp.Services
{
    public class ApiServices
    {
        private string nowPlayingMoviesUrl = "http://colosseum.somee.com/api/NowPlayingMovies";
        private string upComingMovieUrl = "http://colosseum.somee.com/api/UpComingMovies";
        private string bookTicketUrl = "http://colosseum.somee.com/api/Orders";

        private string APIKEY = "ApiKey";
        private string KEY = "e0d9b4e1-0310-4f03-978b-3728d1c77b42";
           

        public async Task<List<NowPlayingMovie>> GetNowPlayingMovies()
        {
            var client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, nowPlayingMoviesUrl);

            requestMessage.Headers.Add(APIKEY, KEY);

            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<NowPlayingMovie>>(movieResponse);
        }

        public async Task<List<NowPlayingMovie>> GetUpComingMovies()
        {
            var client = new HttpClient();

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, upComingMovieUrl);

            requestMessage.Headers.Add(APIKEY, KEY);

            var responseMessage = await client.SendAsync(requestMessage);
            var movieResponse = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<NowPlayingMovie>>(movieResponse);
        }

        public async Task<bool> Order(BookTicket ticket){
            
            var client = new HttpClient();

            var ticketJson = JsonConvert.SerializeObject(ticket);

            var payload = new StringContent(ticketJson, Encoding.UTF8, "application/json");
            payload.Headers.Add(APIKEY, KEY);

            var response = await client.PostAsync(bookTicketUrl, payload);

            return response.IsSuccessStatusCode;

        }


    }
}
