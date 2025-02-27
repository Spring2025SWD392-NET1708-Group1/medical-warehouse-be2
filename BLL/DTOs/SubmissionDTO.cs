using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class SubmissionCreateDTO
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public SubmissionType Type { get; set; }

        [Required]
        public string Context { get; set; } = string.Empty;
    }

    public class SubmissionUpdateDTO
    {
        public SubmissionType? Type { get; set; }
        public string? Context { get; set; }
    }

    public class SubmissionViewDTO
    {
        public Guid SubmissionId { get; set; }
        public string UserName { get; set; } = string.Empty; // From User entity
        public SubmissionType Type { get; set; }
        public string Context { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } // Optional timestamp field
    }

}
