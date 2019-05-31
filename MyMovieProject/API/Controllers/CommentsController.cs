using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ApiDbContext db;

        public CommentsController(ApiDbContext context)
        {
            db = context;
        }

        // GET: api/comments
        [HttpGet]
        public  IActionResult Get()
        {
            var comments = db.Comments;
            return Ok(comments);
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                return Ok(comment);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Comments
        [HttpPost]
        public IActionResult Post([FromBody] Comments comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return Ok(Json(comment));
        }

        // PUT: api/Comments/5
        [HttpPut]
        public IActionResult Put([FromForm]Comments comment)
        {
            var Comment = db.Comments.FirstOrDefault(c => c.Id == comment.Id);
            if (Comment != null)
            {
                db.Comments.Update(comment);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comment = db.Comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                db.Comments.Remove(comment);
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
