namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        // Foreign Key
        public int RoleId { get; set; }
        // Navigation Property
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
