namespace DataAccess.Entities
{
    public class Permission
    {
        public int IdPermission { get; set; }
        public required string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
