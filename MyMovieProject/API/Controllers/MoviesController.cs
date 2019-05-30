using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using API.Models;

namespace API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly ApiDbContext db;

        public MoviesController(ApiDbContext context)
        {
            db = context;
        }

        // GET api/movies
        [HttpGet]
        public IActionResult Get()
        {
            var movies = db.Movies;
            return Ok(movies);
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            } else
            {
                return NotFound();
            }
        }

        // GET api/movies/search
        [HttpPost("search")]
        public IActionResult GetByName([FromForm]string name)
        {
            var movies = db.Movies;
            ICollection<Movies> returnedMovies = null;

            foreach(Movies m in movies)
            {
                if (m.Name.Contains(name))
                {
                    returnedMovies.Add(m);
                }
            }

            if (returnedMovies != null)
            {
                return Ok(returnedMovies);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/movies
        [HttpPost]
        public IActionResult Post([FromBody] Movies movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
            return Ok(Json(movie));
        }

        // PUT api/movies/5
        [HttpPut]
        public IActionResult Put([FromForm]Movies movie)
        {
            var Movie = db.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (Movie != null)
            {
                db.Movies.Update(movie);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
