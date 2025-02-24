using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Submission
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; } = null!; // Ensures navigation property is required

        [Required]
        public SubmissionType Type { get; set; }

        [Required]
        public string Context { get; set; } = string.Empty; // Default to empty string

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // Default timestamp
    }
}
