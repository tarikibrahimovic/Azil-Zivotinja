namespace Azil.Gateway.DTOs.User
{
    public enum Role
    {
        User,
        Admin
    }
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Role Role { get; set; }
    }
}
