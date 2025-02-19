using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class ItemCategory
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
