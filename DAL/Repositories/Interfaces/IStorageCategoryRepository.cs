using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IStorageCategoryRepository
    {
        Task<IEnumerable<StorageCategory>> GetAllAsync();
        Task<StorageCategory?> GetByIdAsync(int id);
        Task AddAsync(StorageCategory category);
        Task DeleteAsync(int id);
        Task UpdateAsync(StorageCategory category);
    }
}
