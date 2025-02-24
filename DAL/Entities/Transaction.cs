using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Transaction
    {
        [Key]
        [Required]
        public Guid TransactionId { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!; // Ensures navigation property is required

        [Required]
        public string TransactionNumber { get; set; } = string.Empty; // Default value to avoid null

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public TransactionStatus Status { get; set; }
    }
}
