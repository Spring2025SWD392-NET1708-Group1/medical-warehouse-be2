namespace BLL.DTOs
{
    public class OrderDetailDTO
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
