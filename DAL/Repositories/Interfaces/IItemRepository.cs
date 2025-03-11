using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task AddAsync(Item item);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item?> GetByIdAsync(Guid id);
        Task UpdateAsync(Item item);

        // New methods to fetch related data
        Task<IEnumerable<Item>> GetAllWithCategoryAndStorageAsync();
        Task<Item?> GetByIdWithCategoryAndStorageAsync(Guid id);


    }
}
