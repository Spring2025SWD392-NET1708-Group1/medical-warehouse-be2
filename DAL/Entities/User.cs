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
        public bool EmailConfirmed { get; set; }
        public Guid? ActivationToken { get; set; }
        public DateTime? ActivationTokenExpires { get; set; }

        public Role Role { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<LotRequest> LotRequests { get; set; } = new List<LotRequest>();
    }
}
