using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Data;
using Survivor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CompetitorController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorEntity>>> GetCompetitors()
        {
            return await _context.Competitors
                .Include(c => c.Category)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitorEntity>> GetCompetitor(int id)
        {
            var competitor = await _context.Competitors
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (competitor == null)
                return NotFound();

            return competitor;
        }

        [HttpGet("categories/{categoryId}")]
        public async Task<ActionResult<IEnumerable<CompetitorEntity>>> GetCompetitorsByCategory(int categoryId)
        {
            return await _context.Competitors
                .Include(c => c.Category)
                .Where(c => c.CategoryId == categoryId && !c.IsDeleted)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CompetitorEntity>> CreateCompetitor(CompetitorEntity competitor)
        {
            competitor.CreatedDate = DateTime.UtcNow;
            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetitor), new { id = competitor.Id }, competitor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompetitor(int id, CompetitorEntity competitor)
        {
            if (id != competitor.Id)
                return BadRequest();

            var existingCompetitor = await _context.Competitors
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (existingCompetitor == null)
                return NotFound();

            existingCompetitor.FirstName = competitor.FirstName;
            existingCompetitor.LastName = competitor.LastName;
            existingCompetitor.CategoryId = competitor.CategoryId;
            existingCompetitor.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetitor(int id)
        {
            var competitor = await _context.Competitors
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (competitor == null)
                return NotFound();

            competitor.IsDeleted = true;
            competitor.ModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
