namespace BLL.DTOs
{
    public class StorageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StorageCategoryId { get; set; }
        public bool IsActive { get; set; }
    }

    public class StorageViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StorageCategoryName { get; set; }
        public bool IsActive { get; set; }

    }

    public class StorageCreateDTO
    {
        public string Name { get; set; }
        public int StorageCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class StorageUpdateDTO
    {
        public string? Name { get; set; }
        public int? StorageCategoryId { get; set; }
        public bool? IsActive { get; set; }
    }
}
