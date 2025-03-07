using System.ComponentModel.DataAnnotations;
namespace DAL.Entities
{
    public class StorageCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Storage> Storages { get; set; }
    }
}

