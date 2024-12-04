
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

    public class ColorsController : ControllerBase {
        private readonly AppDbContext_context;
        public ColorsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>>GetColors()
        {
            return await _context.Colors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(int id){
            var color = await _context.Colors.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }
            return color;

        }

        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color){
            _context.Colors.Add(color);
            await_context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new {id = color.ID}, color);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color){
            if (id != color.Id){
                return BadRequest();
            }
            _context.Entry(color).State=EntityState.Modified;

            try{
                await_context.SaveChangesAsync();
            }
            catch (DbUpdateconcurrencyException){
                if (!_context.Colors.Any(this=>t.Id==id)){
                    return NotFound();
                }
                else{
                    throw;
                }
            }

            return NotContext();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColors(int id){
            var color= await_context.Colors.FindAsync(id);

            if (color==null){
                return NotFound();
            }
            _context.Colors.Remove(color);
            await_context.SaveChangesAsync();

            return NoContent();
        }
    }
}