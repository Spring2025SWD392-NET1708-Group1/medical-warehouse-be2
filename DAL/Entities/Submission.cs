using Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Submission
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FromUserId { get; set; }

        [ForeignKey("FromUserId")]
        public User FromUser { get; set; } = null!;

        public Guid? ToUserId { get; set; }

        [ForeignKey("ToUserId")]
        public User? ToUser { get; set; }
        [ForeignKey("StorageId")]
        public int? StorageId { get; set; }
        public Storage? Storage { get; set; }

        [Required]
        public SubmissionType Type { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Context { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? LastModifiedDate { get; set; } 

        public bool? IsTaskDone { get; set; } = null;

        public bool? IsApproved { get; set; } = null;

    }
}
