using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty; // Plain text password (to be hashed)
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public Guid RoleId { get; set; }
    }

    public class UserViewDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty; // From Role entity
        public bool EmailConfirmed { get; set; }
        public Guid? ActivationToken { get; set; }
    }

    public class UserUpdateDTO
    {
        [Required]
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid? RoleId { get; set; }
        public bool? EmailConfirmed { get; set; }
    }

    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
