using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAllItemsAsync();
        Task<ItemDTO?> GetItemByIdAsync(int id);
        Task<ItemDTO> CreateItemAsync(ItemDTO itemDTO);
        Task<bool> UpdateItemAsync(int id, ItemDTO itemDTO);
        Task<bool> DeleteItemAsync(int id);
    }
}
