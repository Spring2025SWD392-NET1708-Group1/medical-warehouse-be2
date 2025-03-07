using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IItemLotRepository
    {
        Task<IEnumerable<ItemLot>> GetAllAsync();
        Task<ItemLot?> GetByIdAsync(Guid id);
        Task AddAsync(ItemLot itemLot);
        Task UpdateAsync(ItemLot itemLot);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ItemLot>> GetExpiredItemsByDateAsync(DateTime date);
        Task<IEnumerable<ItemLot>> GetByStorageIdAsync(int storageId);
    }
}
