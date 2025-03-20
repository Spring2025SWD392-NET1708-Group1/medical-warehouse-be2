
using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ItemCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        [Required]
        public Guid UserId { get; set; } = Guid.Empty; // Supplier Id

        [Required]
        public Guid ItemCategoryId { get; set; } // Category reference for creation
        [Required]
        public ItemType ItemType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal ImportPricePerUnit { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal? ExportPricePerUnit { get; set; }

    }

    public class ItemUpdateDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ItemCategoryId { get; set; }

        public decimal? ImportPricePerUnit { get; set; }
        public decimal? ExporPricePerUnit { get; set; }
        public bool? IsForSale { get; set; }
    }

    public class ItemViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public string ItemType { get; set; }
        public decimal ImportPricePerUnit { get; set; }
        public decimal ExportPricePerUnit { get; set; }
        public bool IsForSale { get; set; }
    }
}
