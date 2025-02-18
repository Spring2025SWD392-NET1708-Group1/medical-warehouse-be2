using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public int RoleId { get; set; }
        public bool EmailConfirmed { get; set; }
        public Role Role { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
