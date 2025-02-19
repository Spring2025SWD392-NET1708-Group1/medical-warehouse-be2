using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemViewDTO>> GetAllItemsAsync();
        Task<ItemViewDTO?> GetItemByIdAsync(Guid id);
        Task<ItemViewDTO> CreateItemAsync(ItemCreateDTO itemDTO);
        Task<bool> UpdateItemAsync(Guid id, ItemUpdateDTO itemDTO);
        Task<bool> DeleteItemAsync(Guid id);
    }
}
