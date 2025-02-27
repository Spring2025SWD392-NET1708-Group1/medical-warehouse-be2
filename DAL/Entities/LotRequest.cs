using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class LotRequest
    {
        [Key]
        public Guid LotRequestId { get; set; }
        public DateTime StockInDate { get; set; }
        public string Quality { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public LotRequestEnums? Status { get; set; }
        public Guid StaffId { get; set; }
        public User Staff { get; set; }
    }
}
