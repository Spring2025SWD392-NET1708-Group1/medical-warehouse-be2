using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
        public User User { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
