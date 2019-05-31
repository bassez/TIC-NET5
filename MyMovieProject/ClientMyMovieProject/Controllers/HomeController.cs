using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientMyMovieProject.Models;
using PiratesRhumStream.Models;
using System.Diagnostics;

namespace ClientMyMovieProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieDetailService _movieSrv;
        //private readonly CommentService _commentSrv;
        //private readonly SearchService _searchSrv;
        //TODO REPLACE CONSTRUCTOR
        //public HomeController(MovieDetailService _movieDetailService, CommentService _commentService, SearchService _searchService)
        
        public HomeController(MovieDetailService _movieDetailService) {
            _movieSrv = _movieDetailService;
            //_commentSrv = _commentService;
            //_searchSrv = _searchService;
        }
        public IActionResult Index()
            {
            //MovieDetail[] moviesPartType = _movieSrv.GetHomeMoviesPartType();
            //return View(moviesPartType);
            return View();
            }
        public IActionResult Movies()
            {
            //string typeValue = System.Convert.ToString(RouteData.Values["id"]);
            //MovieDetail[] moviesByType= _movieSrv.GetMoviesByType(typeValue);
            //return View(moviesByType);
            return View();
        }

        public IActionResult Search()
            {
                //string searchValue = System.Convert.ToString(RouteData.Values["id"]);
                //MovieDetail[] moviesFound = _searchSrv.Search(searchValue);
                //return View(moviesFound);
                return View();
        }

        public IActionResult MovieDetail()
            {
                int movieId = System.Convert.ToInt32(RouteData.Values["id"]);
                //System.Type type = typeof(int);
                //Console.WriteLine(t);
                //Console.ReadLine();
                MovieDetail movie  = _movieSrv.Get(movieId);
            //Comment[] comments = _commentSrv.Get(movieId);
            //TODO REPLACE RETURN
            //return View(new { movie, comments });
            return View(movie);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
    }
}
