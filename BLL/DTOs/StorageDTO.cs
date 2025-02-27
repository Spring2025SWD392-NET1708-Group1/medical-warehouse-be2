namespace BLL.DTOs
{
  public class StorageDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int StorageCategoryId { get; set; }
    public bool IsActive { get; set; }
  }
}

