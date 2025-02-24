namespace BLL.DTOs
{
    public class RoleViewDTO
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public class RoleCreateDTO
    {
        public string Name { get; set; } = string.Empty;
    }
    public class RoleUpdateDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
