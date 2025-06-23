namespace DataAccess.Entities
{
    public class Order
    {
        public int IdOrder { get; set; }
        public required string OrderNumber { get; set; }
        public required string CustomerName { get; set; }
        public DateTime Date { get; set; }
    }
}
