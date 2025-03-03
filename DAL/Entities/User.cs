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
        // Used to store activation token 
        public Guid? ActivationToken { get; set; }
        // Used to check the validation of token
        public DateTime? ActivationTokenExpires { get; set; }
        public Role Role { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        // Navigation property: LotRequests (Staff managing them)
        public ICollection<LotRequest> LotRequests { get; set; } = new List<LotRequest>();
    }
}
