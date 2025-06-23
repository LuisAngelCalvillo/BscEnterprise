namespace Shared.DTOs
{
    public class InsertOrderDetailDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
}
