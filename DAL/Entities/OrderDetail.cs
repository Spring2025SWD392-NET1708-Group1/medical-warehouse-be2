using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
