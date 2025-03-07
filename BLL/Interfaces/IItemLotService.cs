using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IItemLotService
    {
        Task<IEnumerable<ItemLotViewDTO>> GetAllItemLotsAsync();
        Task<ItemLotViewDTO?> GetItemLotByIdAsync(Guid id);
        Task<ItemLotViewDTO> CreateItemLotAsync(ItemLotCreateDTO itemLotDTO);
        Task<bool> UpdateItemLotAsync(Guid id, ItemLotUpdateDTO itemLotDTO);
        Task<bool> UpdatItemLotAdminAsync(Guid id, ItemLotAdminUpdateDTO itemLotDTO);
        Task<bool> DeleteItemLotAsync(Guid id);
        Task<IEnumerable<ItemLotViewDTO>> GetExpiredItemsByDateAsync(DateTime date);
    }
}

