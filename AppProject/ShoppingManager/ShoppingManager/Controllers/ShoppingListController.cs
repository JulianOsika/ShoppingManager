using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingManager.Domain.Entities;
using ShoppingManager.Dtos;
using ShoppingManager.Infrastructure.Persistence;

namespace ShoppingManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShoppingLists()
        {
            var shoppingLists = await _context.ShoppingLists.ToListAsync();
            return Ok(shoppingLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingListById([FromRoute] int id)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);

            if (shoppingList == null)
            {
                return NotFound();
            }

            return Ok(shoppingList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] CreateShoppingListRequest request)
        {
            var shoppingList = new ShoppingList
            {
                Name = request.Name,
            };

            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAllShoppingLists),
                new { id = shoppingList.Id },
                shoppingList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList([FromRoute] int id)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(id);

            if(shoppingList == null)
            {
                return NotFound();
            }

            _context.ShoppingLists.Remove(shoppingList);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
