
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ItemCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public Guid SupplierId { get; set; } = Guid.Empty;

        [Required]
        public Guid ItemCategoryId { get; set; } // Category reference for creation

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PricePerUnit { get; set; }
    }

    public class ItemUpdateDTO
    {
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ItemCategoryId { get; set; } // Nullable, so updates can be partial

        public decimal? PricePerUnit { get; set; }
    }

    public class ItemViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SupplierName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal PricePerUnit { get; set; }
    }
}
