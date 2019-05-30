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
    public class UsersController : Controller
    {

        private ApiDbContext db = new ApiDbContext();

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
            {
                return new string[] { "user1", "user2" };
            }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
            {
                return "user";
            }

        // POST api/users
        [HttpPost]
        public  ActionResult<string> Post([FromBody] Users user)
            {
                var _user = new Users {
                    Pseudo = user.Pseudo,
                    Email = user.Email
                };
                db.Users.Add(_user);
                db.SaveChanges();
                return Json(user);
            }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string user)
            {
            }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
            {
            }
    }
}
