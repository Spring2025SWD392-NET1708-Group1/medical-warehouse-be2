using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IItemCategoryService
    {
        Task<IEnumerable<ItemCategoryDTO>> GetAllCategoriesAsync();
        Task<ItemCategoryDTO?> GetCategoryByIdAsync(Guid id);
        Task<ItemCategoryDTO> CreateCategoryAsync(ItemCategoryDTO itemcategoryDTO);
        Task<bool> UpdateCategoryAsync(Guid id, ItemCategoryDTO itemcategoryDTO);
        Task<bool> DeleteCategoryAsync(Guid id);
    }
}
