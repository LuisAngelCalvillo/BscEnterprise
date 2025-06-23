namespace DataAccess.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
    }
}
