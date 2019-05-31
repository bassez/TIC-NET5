using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using API.Models;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private string JwtSecret = "S3(r3tT051GN_JWT";
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
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n\n");
                return Json(db.Users.Select(FormatUser));
            }


        // GET api/users/me
        [HttpGet("me")]
        public ActionResult<string> GetMe()
            {
                var id =  System.Convert.ToInt32(this.User.Identity.Name);
                var me = db.Users.Where(u => u.Id == id).Select(FormatUser).ToList()[0];
                return Json(me);
            }


        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
            {
                return Json(db.Users.Where(u => u.Id == id).Select(FormatUser).ToList()[0]);
            }


        // POST api/users
        [AllowAnonymous]
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

                var savedUser = db.Users.Where(u => u.Id == _user.Id).Select(FormatUser).ToList()[0];

                return Json(savedUser);
            }



        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] Users userParam)
            {
                var user = db.Users.Where(u => u.Email == userParam.Email).ToList()[0];

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });
                else if (!Users.ValidatePassword(userParam.Password, user.Password, user.Salt))
                    return Unauthorized(new {message = "Bad email or password"});



                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(JwtSecret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.Name, user.Id.ToString())
                        }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // return basic user info (without password) and token to store client side
                return Ok(new {
                        Id = user.Id,
                        Pseudo = user.Pseudo,
                        Email = user.Email,
                        Birthdate = user.Birthdate,
                        Token = tokenString
                    });
            }


        // PUT api/users/me
        [HttpPut("me")]
        public ActionResult<string> Put(string me, [FromBody] Users  user)
            {
                var id =  System.Convert.ToInt32(this.User.Identity.Name);

                var _user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                var salt = Users.GenSalt();
                var hashedPassword = Users.HashPassword(user.Password, salt);

                _user.Pseudo = user.Pseudo;
                _user.Email = user.Email;
                _user.Password = hashedPassword;
                _user.Salt = salt;


                db.SaveChanges();

                return Json(_user);
            }


        // PUT api/users/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromBody] Users  user)
            {
                var _user = db.Users.Where(u => u.Id == id).FirstOrDefault();
                var salt = Users.GenSalt();
                var hashedPassword = Users.HashPassword(user.Password, salt);

                _user.Pseudo = user.Pseudo;
                _user.Email = user.Email;
                _user.Password = hashedPassword;
                _user.Salt = salt;


                db.SaveChanges();

                return Json(_user);
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
