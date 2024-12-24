using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survivor.Data;
using Survivor.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Survivor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly SurvivorDbContext _context;

        public CategoryController(SurvivorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryEntity>>> GetCategories()
        {
            return await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryEntity>> GetCategory(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryEntity>> CreateCategory(CategoryEntity category)
        {
            category.CreatedDate = DateTime.UtcNow;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryEntity category)
        {
            if (id != category.Id)
                return BadRequest();

            var existingCategory = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (existingCategory == null)
                return NotFound();

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            existingCategory.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

            if (category == null)
                return NotFound();

            category.IsDeleted = true;
            category.ModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
