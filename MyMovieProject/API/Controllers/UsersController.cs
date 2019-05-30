using System;
using System.Globalization;
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

        public Func<Users, object> FormatUser = user => new {
            id = user.Id,
            pseudo = user.Pseudo,
            email = user.Email,
            birthdate = user.Birthdate,
            dateCreated = user.Date_Created
        };

        // GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
            {
                return Json(db.Users.Select(FormatUser));
            }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
            {
                return Json(db.Users.Where(user => user.Id == id).Select(FormatUser).ToList()[0]);
            }

        // POST api/users
        [HttpPost]
        public ActionResult<string> Post([FromBody] Users user)
            {
                var salt = Users.GenSalt();
                var hashedPassword = Users.HashPassword(user.Password, salt);

                var _user = new Users {
                    Pseudo = user.Pseudo,
                    Email = user.Email,
                    Password = hashedPassword,
                    Salt = salt,
                    Birthdate = user.Birthdate,
                    Date_Created = System.DateTime.Now
                };
                db.Users.Add(_user);
                db.SaveChanges();

                return Json(_user);
            }



        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] Users userParam)
            {
                var user = db.Users.Where(u => u.Email == userParam.Email).ToList()[0];

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                if (Users.ValidatePassword(userParam.Password, user.Password, user.Salt))
                    return Ok(Json(user));
                else
                    return Unauthorized(new {message = "Bad email or password"});
            }


        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users  user)
            {

            }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
            {
                var user = db.Users.Where(u => u.Id == id);
                var user_ = user.Select(FormatUser).ToList()[0];

                db.Users.Remove(user.SingleOrDefault());
                db.SaveChanges();
                return Json(user_);
            }
    }
}
