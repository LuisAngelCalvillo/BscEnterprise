namespace DataAccess.Entities
{
    public class Product
    {
        public int IdProduct  { get; set; }
        public required string ProductKey { get; set; }
        public required string Name { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
