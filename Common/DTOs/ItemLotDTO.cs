using Common.Enums;

namespace Common.DTOs
{
    public class ItemLotViewDTO
    {
        public Guid ItemLotId { get; set; }
        public string Quality { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public required ItemViewDTO Item { get; set; }
        public string Status { get; set; } = string.Empty;
        public string StorageName { get; set; } = string.Empty;
        public DateTime ExpiryDate { get; set; }
    }

    public class ItemLotCreateDTO
    {
        public string Quality { get; set; } = string.Empty;
        public int Quantity { get; set; }   
        public Guid ItemId { get; set; }
        public DateTime ExpiryDate { get; set; }
    }

    public class ItemLotUpdateDTO
    {
        public int? StorageId { get; set; }
        public LotStatus? Status { get; set; }
        public string? Quality { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    public class ItemLotAdminUpdateDTO
    {
        public Guid? ItemLotId { get; set; }
        public Guid? ItemId { get; set; }
        public int? StorageId { get; set; }
        public string? Quality { get; set; }
        public int? Quantity { get; set; }
        public LotStatus? Status { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}