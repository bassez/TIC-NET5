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
    public class MoviesController : Controller
    {
        // GET api/movies
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
            {
                return new string[] { "movie1", "movie2" };
            }

        // GET api/movies/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
            {
                if (id == 1)
                {
                    return Ok(new Movies() { Id = 1, Name = "Endgame", Category = "Action" });
                } else
                {
                    return NotFound();
                }
            }

        // POST api/movies
        [HttpPost]
        public ActionResult<string> Post([FromBody] string movie)
            {
                return Ok("Created");
            }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string movie)
            {
            }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
            {
            }
    }
}
