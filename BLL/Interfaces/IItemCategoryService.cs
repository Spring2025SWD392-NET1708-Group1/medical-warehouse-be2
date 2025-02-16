using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<ItemCategoryDTO>> GetAllCategoriesAsync();
        Task<ItemCategoryDTO?> GetCategoryByIdAsync(int id);
        Task<ItemCategoryDTO> CreateCategoryAsync(ItemCategoryDTO itemcategoryDTO);
        Task<bool> UpdateCategoryAsync(int id, ItemCategoryDTO itemcategoryDTO);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
