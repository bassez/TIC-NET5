using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/likes")]
    [ApiController]
    public class LikesController : Controller
    {
        private readonly ApiDbContext db;

        public LikesController(ApiDbContext context)
        {
            db = context;
        }

        // GET: api/likes
        [HttpGet]
        public IActionResult Get()
        {
            var likes = db.Likes;
            return Ok(likes);
        }

        // GET: api/likes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var like = db.Likes.FirstOrDefault(l => l.Id == id);
            if (like != null)
            {
                return Ok(like);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/likes
        [HttpPost]
        public IActionResult Post([FromBody]Likes like)
        {
            db.Likes.Add(like);
            db.SaveChanges();
            return Ok(Json(like));
        }

        // PUT: api/likes/5
        [HttpPut]
        public IActionResult Put([FromBody]Likes like)
        {
            var Like = db.Likes.FirstOrDefault(l => l.Id == like.Id);
            if (Like != null)
            {
                db.Likes.Update(like);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/likes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var like = db.Likes.FirstOrDefault(l => l.Id == id);
            if (like != null)
            {
                db.Likes.Remove(like);
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
