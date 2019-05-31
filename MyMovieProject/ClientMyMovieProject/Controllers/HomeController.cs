using System;
using System.Web;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientMyMovieProject.Models;
using PiratesRhumStream.Models;

using System.Net.Http;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;

namespace ClientMyMovieProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDetailService _service;
        public HomeController(MovieDetailService service) {
            _service = service;
        }
        public IActionResult Index()
            {
                return View();
            }
        public IActionResult Movies()
            {
                return View();
            }

        public IActionResult Search()
            {
                return View();
            }

        public IActionResult MovieDetail()
            {
                var detail = _service.Get(3);
                return View(detail);
            }

        public IActionResult ModifyAccount()
            {
                return View();
            }

        public IActionResult Account()
            {
                return View();
            }




        [HttpPost]
        public IActionResult Register(Users user)
            {
                HttpClient client = new HttpClient();
                var url = "http://localhost:5000/api/users/";
                var _user = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var content = new StringContent(_user, Encoding.UTF8, "application/json");
                var result = client.PostAsync(url, content).Result;

                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(result));

                if (result.IsSuccessStatusCode) {
                    return Redirect("/Home/SignIn");
                } else {
                    return View();
                }

            }


        [HttpPost]
        public IActionResult Signin(Users user)
            {

                HttpClient client = new HttpClient();
                var url = "http://localhost:5000/api/users/authenticate";
                var _user = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var content = new StringContent(_user, Encoding.UTF8, "application/json");
                var result =  client.PostAsync(url, content).Result;
                var contents = result.Content.ReadAsStringAsync().Result;


                JObject jsonRes = JObject.Parse(contents);

                Console.WriteLine("NOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPENOPE");
                Console.WriteLine(jsonRes["token"]);

                if (result.IsSuccessStatusCode) {
                    System.Web.HttpContext.Current.Session["JWT"] = jsonRes["token"];
                    return Redirect("/Home");
                } else {
                    return View();
                }

            }



        public IActionResult Register()
            {
                return View();
            }
        public IActionResult SignIn()
            {
                return View();
            }

        public IActionResult Privacy()
            {
                return View();
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
    }
}
