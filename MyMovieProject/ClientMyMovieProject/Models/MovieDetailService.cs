using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;

namespace PiratesRhumStream.Models
{
    public class MovieDetailService
    {
        HttpClient _client = new HttpClient();
        public MovieDetail Get(int id) {
            var url = "http://localhost:5000/api/movies/";
            // TODO BOEHM
            var resp = _client.GetAsync(url + id).Result;
            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MovieDetail>(resp.Content.ReadAsStringAsync().Result);
            return null;
        }

        public MovieDetail[] GetMovies()
        {
            var url = "http://localhost:5000/api/movies/";
            // TODO BOEHM
            var resp = _client.GetAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MovieDetail[]>(resp.Content.ReadAsStringAsync().Result);
            return null;
        }
    }
}
