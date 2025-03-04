
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class ItemCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public Guid ItemCategoryId { get; set; } // Category reference for creation

        [Required]
        public int StorageId { get; set; } // Storage reference for creation

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }
    }

    public class ItemUpdateDTO
    {
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public Guid? ItemCategoryId { get; set; } // Nullable, so updates can be partial

        public int? StorageId { get; set; } // Nullable, allows storage changes

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public DateTime? ExpiryDate { get; set; }
    }

    public class ItemViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string StorageName { get; set; } = string.Empty; // Display Storage Name
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
