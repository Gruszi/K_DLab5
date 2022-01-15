using K_DLab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace K_DLab5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutaController : ControllerBase
    {
        private readonly CarContext _context;

        public AutaController(CarContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarItems()
        {
            return await _context.CarItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.CarItems.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            _context.Entry(car).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            _context.CarItems.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.CarItems.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.CarItems.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.CarItems.Any(e => e.Id == id);
        }
    }
}
