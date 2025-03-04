using BLL.DTOs;
namespace BLL.Interfaces
{
    public interface IStorageService
    {
        Task<IEnumerable<StorageViewDTO>> GetAllStoragesAsync();
        Task<StorageViewDTO?> GetStorageByIdAsync(int id);
        Task<StorageViewDTO> CreateStorageAsync(StorageCreateDTO storageDTO);
        Task<bool> UpdateStorageAsync(int id, StorageUpdateDTO storageDTO);
        Task<bool> DeleteStorageAsync(int id);
        Task<IEnumerable<StorageViewDTO>> GetStoragesByCategoryIdAsync(int categoryId);
    }
}
