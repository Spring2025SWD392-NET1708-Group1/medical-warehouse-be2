using Common.Enums;
using DAL.Entities;
using System.Diagnostics.Contracts;

namespace BLL.DTOs
{
    public class LotRequestViewDTO
    {
        public Guid LotRequestId { get; set; }
        public string Quality { get; set; } = string.Empty;
        public required ItemViewDTO Item { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StorageName { get; set; } = string.Empty;
    }

    public class LotRequestCreateDTO
    {
        public string Quality { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
        public Guid UserId { get; set; }
        public int StorageId { get; set; }
    }

    public class LotRequestUpdateDTO
    {
        public int? StorageId { get; set; }
        public LotRequestEnums? Status { get; set; }
    }

    public class LotRequestAdminUpdateDTO
    {
        public Guid? LotRequestId { get; set; }
        public Guid? ItemId { get; set; }
        public Guid? UserId { get; set; }
        public int? StorageId { get; set; }
        public string? Quality { get; set; }
        public LotRequestEnums? Status { get; set; }
    }
}