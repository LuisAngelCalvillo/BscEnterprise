namespace DataAccess.Entities
{
    public class DetailOrder
    {
        public int IdDetailOrder { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
