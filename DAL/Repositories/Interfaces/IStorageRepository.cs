using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
