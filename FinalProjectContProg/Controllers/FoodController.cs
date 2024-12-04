
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectContProg.Data;
using FinalProjectContProg.Models;


namespace FinalProjectContProg.Controllers{
    [Route("api/[controller]")]
    [ApiController]

    public class FoodController : ControllerBase {
        private readonly AppDbContext_context;
        public FoodController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>>GetFood()
        {
            return await _context.Food.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id){
            var food = await _context.Food.FindAsync(id);

            if (food == null)
            {
                return NotFound();
            }
            return food;

        }

        [HttpPost]
        public async Task<ActionResult<Food>> PostFood(Food food){
            _context.Food.Add(food);
            await_context.SaveChangesAsync();

            return CreatedAtAction("GetFood", new {id = Food.ID}, food);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food){
            if (id != food.Id){
                return BadRequest();
            }
            _context.Entry(food).State=EntityState.Modified;

            try{
                await_context.SaveChangesAsync();
            }
            catch (DbUpdateconcurrencyException){
                if (!_context.Food.Any(this=>t.Id==id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return NotContext();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id){
            var food= await_context.Food.FindAsync(id);

            if (food==null){
                return NotFound();
            }
            _context.Food.Remove(color);
            await_context.SaveChangesAsync();

            return NoContent();
        }
    }
}