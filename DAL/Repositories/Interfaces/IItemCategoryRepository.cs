using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IItemCategoryRepository
    {
        Task<IEnumerable<ItemCategory>> GetAllAsync();
        Task<ItemCategory?> GetByIdAsync(Guid id);
        Task AddAsync(ItemCategory category);
        Task UpdateAsync(ItemCategory category);
        Task DeleteAsync(Guid id);
    }
}
