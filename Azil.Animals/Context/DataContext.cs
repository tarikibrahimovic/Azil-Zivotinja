using Azil.Animals.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Azil.Animals.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }
    }
}
