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
        [Required]
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public decimal Price { get; set; }
    }
}
