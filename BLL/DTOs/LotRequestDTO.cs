using Common.Enums;

namespace BLL.DTOs
{
    public class LotRequestViewDTO
    {
        public Guid LotRequestId { get; set; }
        public string Quality { get; set; } = string.Empty;
        public required ItemViewDTO Item { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class LotRequestCreateDTO
    {
        public string Quality { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
        public Guid StaffId { get; set; }
    }

    public class LotRequestUpdateDTO
    {
        public string? Quality { get; set; } = string.Empty;
        public Guid? ItemId { get; set; }
        public LotRequestEnums? Status { get; set; }
    }

}