namespace Azil.Animals.Models
{
    public enum AnimalType { Dog, Cat, Bird, Fish, Reptile, Rodent, Other}
    public class Animal
    {
        public int Id { get; set; }
        public AnimalType AnimalType { get; set; } = AnimalType.Other;
        public string Name { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExitDate { get; set; } = null;
    }
}
