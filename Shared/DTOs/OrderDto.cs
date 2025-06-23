namespace Shared.DTOs
{
    public class OrderDto
    {
        public int IdOrder { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
    }
}
