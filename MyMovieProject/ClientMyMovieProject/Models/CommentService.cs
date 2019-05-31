using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;

namespace PiratesRhumStream.Models
{
    public class CommentService
    {
        HttpClient _client = new HttpClient();
        public Comment[] Get(int id) {
            var url = "http://localhost:5000/api/comments/";
            // TODO BOEHM
            HttpResponseMessage resp = _client.GetAsync(url + id).Result;

            if (resp.IsSuccessStatusCode)
            {
                //Console.WriteLine(JsonConvert.DeserializeObject<MovieDetail>(resp.Content.ReadAsStringAsync().Result));
                //Console.ReadLine();
                return JsonConvert.DeserializeObject<Comment[]>(resp.Content.ReadAsStringAsync().Result);
            }
            return null;
        }
    }
}
