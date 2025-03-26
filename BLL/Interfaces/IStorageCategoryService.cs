using Common.DTOs;

namespace Common.Interfaces
{
    public interface IStorageCategoryService
    {
        Task<IEnumerable<StorageCategoryViewDTO>> GetAllStorageCategoriesAsync();
        Task<StorageCategoryViewDTO?> GetStorageCategoryByIdAsync(int id);
        Task<StorageCategoryViewDTO> CreateStorageCategoryAsync(StorageCategoryCreateDTO createDTO);
        Task<bool> UpdateStorageCategoryAsync(int id, StorageCategoryUpdateDTO updateDTO);
        Task<bool> DeleteStorageCategoryAsync(int id);
    }
}
