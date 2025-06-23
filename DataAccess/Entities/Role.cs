namespace DataAccess.Entities
{
    public class Role
    {
        public int IdRole { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
