using Azil.Animals.Broker;
using Azil.Animals.Context;
using Azil.Animals.DTOs;
using Azil.Animals.Models;

namespace Azil.Animals.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMessageBroker _messageBroker;
        private readonly DataContext _context;
        public AnimalService(IMessageBroker messageBroker, DataContext context)
        {
            _messageBroker = messageBroker;
            _context = context;
        }

        public List<Animal> GetAllAnimals()
        {
            List<Animal> animals = _context.Animals.ToList();
            return animals;
        }

        public Animal RegisterAnimal(AnimalRegisterDto request)
        {
            Animal animal = new Animal
            {
                Name = request.Name,
                AnimalType = request.AnimalType,
                EntryDate = DateTime.UtcNow
            };
            _context.Animals.Add(animal);
            _context.SaveChanges();
            _messageBroker.Publish(request);

            return animal;
        }
    }
}
