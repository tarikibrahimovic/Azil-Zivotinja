using Azil.Gateway.Models;

namespace Azil.Gateway.DTOs.Animal
{
    public class AnimalRegisterDto
    {
        public AnimalType AnimalType { get; set; } = AnimalType.Other;
        public string Name { get; set; } = string.Empty;
    }
}
