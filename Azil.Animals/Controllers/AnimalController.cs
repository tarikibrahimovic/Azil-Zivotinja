using Azil.Animals.Context;
using Azil.Animals.DTOs;
using Azil.Animals.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Azil.Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly DataContext _context;

        public AnimalController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("register-animal")]
        public async Task<ActionResult<Animal>> RegisterAnimal(AnimaRegisterDto request)
        {
            Animal animal = new Animal
            {
                AnimalType = request.AnimalType,
                Name = request.Name
            };
            await _context.Animals.AddAsync(animal);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Animal successfully registered!" });
        }

        [HttpPost("take-animal")]
        public async Task<ActionResult<string>> TakeAnimal(AnimalTakeDto request)
        {
            Animal animal = await _context.Animals.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (animal == null)
            {
                return BadRequest("Animal does not exist.");
            }
            if (animal.ExitDate != null)
            {
                return BadRequest("Animal is already taken.");
            }
            animal.ExitDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return Ok(animal);
        }
    }
}
