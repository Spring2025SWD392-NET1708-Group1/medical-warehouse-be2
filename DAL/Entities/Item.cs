using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public Guid ItemCategoryId { get; set; }
        public ItemCategory ItemCategory { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }


    }
}
