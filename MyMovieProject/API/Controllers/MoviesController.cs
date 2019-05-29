using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
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
                return "movie";
            }

        // POST api/movies
        [HttpPost]
        public void Post([FromBody] string movie)
            {
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
