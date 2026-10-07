using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PractiseProg6213Tut.Data;
using PractiseProg6213Tut.Models;

namespace PractiseProg6213Tut.Controllers
{
    [Route("api/workshops")]
    [ApiController]
    public class WorkshopsController : ControllerBase
    {
        private readonly SkillForgeDbContext _context;

        public WorkshopsController(SkillForgeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workshop>>> GetWorkshops()
        {
            return await _context.Workshops
                .Include(w => w.Categories)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workshop>> GetWorkshop(int id)
        {
            var workshop = await _context.Workshops
                .Include(w => w.Categories)
                .FirstOrDefaultAsync(w => w.WorkshopID == id);

            if (workshop == null) return NotFound();
            return workshop;
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorkshop([FromBody] Workshop workshop)
        {
            // Temporarily bypass login check for testing
            HttpContext.Session.SetString("Role", "Instructor");

            // Prevent EF Core tracking/duplicate key conflicts on existing related entities
            workshop.Instructor = null;

            // Ensure new categories have ID 0 so database auto-generates them
            foreach (var category in workshop.Categories)
            {
                category.CategoryID = 0;
            }

            _context.Workshops.Add(workshop);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkshop), new { id = workshop.WorkshopID }, workshop);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkshop(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Instructor")
                return StatusCode(403, new { message = "Access denied. Instructor role required." });

            var workshop = await _context.Workshops.FindAsync(id);
            if (workshop == null) return NotFound();

            _context.Workshops.Remove(workshop);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}