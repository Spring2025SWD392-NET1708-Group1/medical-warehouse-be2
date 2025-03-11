using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class ItemLot
    {
        [Key]
        public Guid ItemLotId { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public int? StorageId { get; set; }
        public Storage? Storage { get; set; }
        public int Quantity { get; set; }
        public string Quality { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
        public LotStatus? Status { get; set; }
    }
}
