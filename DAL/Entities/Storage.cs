using System.ComponentModel.DataAnnotations;
namespace DAL.Entities
{
  public class Storage
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int StorageCategoryId { get; set; }
    public StorageCategory StorageCategory { get; set; }

    [Required]
    public bool IsActive { get; set; } = true;

    // Navigation property for related items
    public ICollection<Item> Items { get; set; } = new List<Item>();
  }
}
