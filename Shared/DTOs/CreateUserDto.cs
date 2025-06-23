namespace Shared.DTOs
{
    public class CreateUserDto
    {
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public int RoleId { get; set; }
    }
}
