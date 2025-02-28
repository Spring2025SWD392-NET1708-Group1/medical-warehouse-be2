using BLL.DTOs;
namespace BLL.Interfaces
{
  public interface IStorageService
  {
    Task<IEnumerable<StorageDTO>> GetAllStoragesAsync();
    Task<StorageDTO> GetStorageByIdAsync(int id);
    Task<StorageViewDTO> CreateStorageAsync(StorageCreateDTO storageDTO);
    Task<bool> UpdateStorageAsync(int id, StorageUpdateDTO storageDTO);
    Task<bool> DeleteStorageAsync(int id);
    Task<IEnumerable<StorageDTO>> GetStoragesByCategoryIdAsync(int categoryId);
  }
}
