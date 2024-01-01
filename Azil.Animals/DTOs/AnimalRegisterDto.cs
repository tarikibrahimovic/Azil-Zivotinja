using Azil.Animals.Models;

namespace Azil.Animals.DTOs
{
    public class AnimalRegisterDto
    {
        public AnimalType AnimalType { get; set; } = AnimalType.Other;
        public string Name { get; set; } = string.Empty;
    }
}
