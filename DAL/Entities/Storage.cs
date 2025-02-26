using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
  public class Storage
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int StorageCategoryId { get; set; }

    [Required]
    public double Capacity { get; set; } // Capacity in cubic meters or liters

    [Required]
    public bool IsActive { get; set; } = true;
  }
}
