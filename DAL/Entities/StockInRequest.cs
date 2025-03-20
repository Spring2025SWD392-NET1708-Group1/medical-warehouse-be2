using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StockInRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string Quality { get; set; }
        public DateTime ExpiryDate { get; set; }
        public StockInRequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
