namespace Shared.DTOs
{
    public class UserLoginDto
    {
        public int IdUser { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string RoleName { get; set; }
    }
}
