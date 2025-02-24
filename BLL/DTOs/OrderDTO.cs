
using Common.Enums;
using DAL.Entities;

namespace BLL.DTOs
{
    public class OrderViewDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        // You can include OrderDetails in this view DTO
        public List<OrderDetailViewDTO> OrderDetails { get; set; } = [];
    }

    public class OrderCreateDTO
    {
        public Guid UserId { get; set; }
        public required List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderUpdateDTO
    {
        public OrderStatus? Status { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
