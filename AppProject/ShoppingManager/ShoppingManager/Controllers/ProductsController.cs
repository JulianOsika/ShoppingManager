using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingManager.Domain.Entities;
using ShoppingManager.Dtos;
using ShoppingManager.Infrastructure.Persistence;

namespace ShoppingManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Unit = request.Unit,
                Company = request.Company,
                Description = request.Description,
                CategoryId = request.CategoryId
            };

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAllProducts),
                new { id = product.Id },
                product);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);

            if( product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] CreateProductRequest request)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null )
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Unit = request.Unit;
            product.Company = request.Company;
            product.Description = request.Description;
            product.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync();

            return Ok(product);
        }

    }
}
