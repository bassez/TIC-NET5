using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;

namespace PiratesRhumStream.Models
{
    public class SearchService
    {
        HttpClient _client = new HttpClient();
        public MovieDetail[] Search(string searchValue) {
            var url = "http://localhost:5000/api/search/?search=" + searchValue;
            //  OU var url = "http://localhost:5000/api/search/" + searchValue;
            HttpResponseMessage resp = _client.GetAsync(url).Result;
            if (resp.IsSuccessStatusCode)
            {
                //Console.WriteLine(JsonConvert.DeserializeObject<MovieDetail>(resp.Content.ReadAsStringAsync().Result));
                //Console.ReadLine();
                return JsonConvert.DeserializeObject<MovieDetail[]>(resp.Content.ReadAsStringAsync().Result);
            }
            return null;
        }
    }
}
