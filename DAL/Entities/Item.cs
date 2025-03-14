using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public Guid ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }
        // Define which Supplier offer to supply this Item
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ItemType UnitType { get; set; }
        public decimal ImportPricePerUnit { get; set; }
        public decimal? ExportPricePerUnit { get; set; }
        public bool IsForSale { get; set; }
    }
}
