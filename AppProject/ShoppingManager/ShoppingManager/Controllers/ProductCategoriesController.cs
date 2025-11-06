using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingManager.Domain.Entities;
using ShoppingManager.Infrastructure.Persistence;
using ShoppingManager.Dtos;

namespace ShoppingManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategories()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductCategory([FromBody] CreateCategoryRequest request)
        {
            var productCategory = new ProductCategory
            {
                Name = request.Name
            };

            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProductCategories),
                new { id = productCategory.Id },
                productCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory([FromRoute] int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductCategory([FromRoute] int id, [FromBody] CreateCategoryRequest request)
        {
            var category = await _context.ProductCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = request.Name;
            await _context.SaveChangesAsync();

            return Ok(category);
        }

    }
}
