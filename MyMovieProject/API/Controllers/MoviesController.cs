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
    public class MoviesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public MoviesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET api/movies
        [HttpGet]
        public IActionResult Get()
        {
            var movies = _context.Movies;
            return Ok(movies);
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            } else
            {
                return NotFound();
            }
        }

        // POST api/movies
        [HttpPost]
        public IActionResult Post([FromForm]Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/movies/5
        [HttpPut]
        public IActionResult Put([FromForm]Movies movie)
        {
            var Movie = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (Movie != null)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
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
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
