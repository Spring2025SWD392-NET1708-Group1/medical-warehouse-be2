using BLL.DTOs;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IItemService
    {
        Task<Item> CreateItemAsync(ItemCreateDTO itemDTO);
        Task<bool> DeleteItemAsync(Guid id);
        Task<IEnumerable<ItemViewDTO>> GetAllItemsWithDetailsAsync(); // Updated method
        Task<ItemViewDTO?> GetItemByIdWithDetailsAsync(Guid id); // Updated method
        Task<bool> UpdateItemAsync(Guid id, ItemUpdateDTO itemDTO);
    }
}
