using Azil.Authorization.Models;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Security.Cryptography;

namespace Azil.Authorization.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
