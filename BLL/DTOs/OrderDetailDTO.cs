using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class OrderDetailCreateDTO
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public Guid ItemId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal UnitPrice { get; set; }
    }

    public class OrderDetailUpdateDTO
    {
        [Required]
        public Guid Id { get; set; } // Needed to identify the existing record
        public Guid? OrderId { get; set; }
        public Guid? ItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }

    public class OrderDetailViewDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; } // From Order entity
        public string ItemName { get; set; } = string.Empty; 
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice; // Computed field
    }
}
