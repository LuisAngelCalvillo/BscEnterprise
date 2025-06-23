namespace Shared.DTOs
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string ProductKey { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Stock { get; set; }
    }
}
