
namespace BLL.DTOs
{
    public class OrderDTO
    {
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderDetailViewDTO> OrderDetails { get; set; } = new();
    }
}
