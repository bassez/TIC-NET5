﻿using System;
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
            HttpResponseMessage resp = _client.GetAsync(url + id).Result;

            if (resp.IsSuccessStatusCode)
            {
                //Console.WriteLine(JsonConvert.DeserializeObject<MovieDetail>(resp.Content.ReadAsStringAsync().Result));
                //Console.ReadLine();
                return JsonConvert.DeserializeObject<MovieDetail>(resp.Content.ReadAsStringAsync().Result);
            }
            return null;
        }

        public MovieDetail[] GetMovies()
        {
            var url = "http://localhost:5000/api/movies/";
            HttpResponseMessage resp = _client.GetAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MovieDetail[]>(resp.Content.ReadAsStringAsync().Result);
            return null;
        }

        public MovieDetail[] GetMoviesByType(string type)
        {
            var url = "http://localhost:5000/api/movies/?type=" + type;
            //  OU var url = "http://localhost:5000/api/moveis/" + type;
            HttpResponseMessage resp = _client.GetAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MovieDetail[]>(resp.Content.ReadAsStringAsync().Result);
            return null;
        }

        public MovieDetail[] GetHomeMoviesPartType()
        {
            // censer retourner 4 films par format (4 exclus, 4 vostfr, 4 vo, 4 OAV)
            var url = "http://localhost:5000/api/movies/partType";
            HttpResponseMessage resp = _client.GetAsync(url).Result;
            if (resp.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<MovieDetail[]>(resp.Content.ReadAsStringAsync().Result);
            return null;
        }
    }
}
