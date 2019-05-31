using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientMyMovieProject.Models;
using PiratesRhumStream.Models;

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
                return View(_service.Get(1));
            }

        public IActionResult ModifyAccount()
            {
                return View();
            }

        public IActionResult Account()
            {
                return View();
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
