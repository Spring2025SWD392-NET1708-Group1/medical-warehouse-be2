namespace Common.DTOs
{
    public class StorageCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StorageCategoryViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StorageCategoryCreateDTO
    {
        public string Name { get; set; }
    }

    public class StorageCategoryUpdateDTO
    {
        public string? Name { get; set; }
    }
}
