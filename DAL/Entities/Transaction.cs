using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Transaction
    {
        [Key]
        [Required]
        public Guid TransactionId { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public string TransactionNumber { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public TransactionStatus Status { get; set; }
    }
}
