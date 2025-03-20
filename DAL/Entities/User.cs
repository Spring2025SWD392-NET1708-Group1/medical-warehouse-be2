using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public Guid? ActivationToken { get; set; }
        public DateTime? ActivationTokenExpires { get; set; }
        public int? StorageId { get; set; }
        public Storage? Storage { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Item> Items { get; set; } = new List<Item>();
        public ICollection<Submission> SentSubmissions { get; set; } = new List<Submission>();  // FromUser
        public ICollection<Submission> ReceivedSubmissions { get; set; } = new List<Submission>();  // ToUser
        public ICollection<StockInRequest> StockInRequests { get; set;} = new List<StockInRequest>();
    }
}
