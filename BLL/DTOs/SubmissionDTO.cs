using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class SubmissionCreateDTO
    {
        [Required]
        public Guid FromUserId { get; set; }
        public Guid? ToUserId { get; set; }
        public int? StorageId { get; set; }

        [Required]
        public SubmissionType Type { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Context { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

    public class SubmissionUpdateDTO
    {
        public SubmissionType? Type { get; set; }
        public string? Context { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsTaskDone { get; set; }
    }

    public class SubmissionViewDTO
    {
        public Guid SubmissionId { get; set; }
        public string FromUserName { get; set; } = string.Empty;
        public string? ToUserName { get; set; } = string.Empty;
        public string? StorageName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Context { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsTaskDone { get; set; }
    }


}
