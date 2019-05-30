using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ValuesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var Movies = _context.Movies;
            return Ok(Movies);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (Movie != null)
            {
                return Ok(Movie);
            } else
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Movies movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(Movies movie)
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Movies movie)
        {
            var Movie = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);
            if (Movie != null)
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
