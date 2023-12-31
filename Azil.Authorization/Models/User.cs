using System.ComponentModel.DataAnnotations;

namespace Azil.Authorization.Models
{
    public enum Role
    {
        User,
        Admin
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}
