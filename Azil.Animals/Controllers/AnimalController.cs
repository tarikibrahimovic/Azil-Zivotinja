using Azil.Animals.DTOs;
using Azil.Animals.Models;
using Azil.Animals.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azil.Animals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService service)
        {
            _animalService = service;
        }

        [HttpPost("register-animal")]
        public ActionResult<Animal> RegisterAnimal(AnimalRegisterDto request)
        {
            var animal = _animalService.RegisterAnimal(request);
            return Ok(animal);
        }

        [HttpGet("get-all-animals")]
        public ActionResult<Animal> GetAllAnimals()
        {
            var animals = _animalService.GetAllAnimals();
            return Ok(animals);
        }

        [HttpGet("check-animal/{id}")]
        public ActionResult<Animal> CheckAnimal(int id)
        {
            var animal = _animalService.CheckAnimal(id);
            if(animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }
        
    }
}
