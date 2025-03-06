using DAL.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IStorageRepository
    {
        Task<IEnumerable<Storage>> GetAllAsync();
        Task<Storage?> GetByIdAsync(int id);
        Task<IEnumerable<Storage>> GetByCategoryIdAsync(int categoryId);
        Task AddAsync(Storage storage);
        Task UpdateAsync(Storage storage);
        Task DeleteAsync(int id);
        Task<Storage?> GetStorageByNameAsync(string name);
    }
}
