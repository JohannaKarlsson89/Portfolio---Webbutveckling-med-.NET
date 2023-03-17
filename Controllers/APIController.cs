using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public APIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projects>>> GetProjects()
        {
          if (_context.Projects == null)
          {
              return NotFound();
          }
            return await _context.Projects.ToListAsync();
        }

        // GET: api/API/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjects(int id)
        {
          if (_context.Projects == null)
          {
              return NotFound();
          }
            var projects = await _context.Projects.FindAsync(id);

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }

        // PUT: api/API/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjects(int id, Projects projects)
        {
            if (id != projects.ProjectsId)
            {
                return BadRequest();
            }

            _context.Entry(projects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/API
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projects>> PostProjects(Projects projects)
        {
          if (_context.Projects == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Projects'  is null.");
          }
            _context.Projects.Add(projects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjects", new { id = projects.ProjectsId }, projects);
        }

        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }
            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectsExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectsId == id)).GetValueOrDefault();
        }
    }
}
