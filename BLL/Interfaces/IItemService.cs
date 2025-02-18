using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDTO>> GetAllItemsAsync();
        Task<ItemDTO?> GetItemByIdAsync(Guid id);
        Task<ItemDTO> CreateItemAsync(ItemDTO itemDTO);
        Task<bool> UpdateItemAsync(Guid id, ItemDTO itemDTO);
        Task<bool> DeleteItemAsync(Guid id);
    }
}
