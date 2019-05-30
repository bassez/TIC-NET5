using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public NotesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/notes
        [HttpGet]
        public IActionResult Get()
        {
            var notes = _context.Notes;
            return Ok(notes);
        }

        // GET: api/notes/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                return Ok(note);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Notes
        [HttpPost]
        public IActionResult Post([FromForm] Notes note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
            return Ok();
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public IActionResult Put([FromForm] Notes note)
        {
            var Notes = _context.Notes.FirstOrDefault(n => n.Id == note.Id);
            if (Notes != null)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/notes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = _context.Notes.FirstOrDefault(n => n.Id == id);
            if (note != null)
            {
                _context.Notes.Remove(note);
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
