using Azil.Animals.DTOs;
using Azil.Animals.Models;

namespace Azil.Animals.Services
{
    public interface IAnimalService
    {
        Animal RegisterAnimal(AnimalRegisterDto request);
        List<Animal> GetAllAnimals();
        Animal CheckAnimal(int id);
    }
}
