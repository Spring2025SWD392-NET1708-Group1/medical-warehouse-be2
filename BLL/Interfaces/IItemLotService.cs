using Common.DTOs;

namespace Common.Interfaces
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
        Task<IEnumerable<ItemLotViewDTO>> GetItemLotByStorageAsync(int id);
        Task<IEnumerable<ItemLotViewDTO>> GetByItemIdAsync(Guid itemId);
        Task<IEnumerable<ItemLotViewDTO>> GetByStorageIdForStaffAsync();
        Task<IEnumerable<ItemLotViewDTO>> GetLotCreateRequestAsync();
    }
}

