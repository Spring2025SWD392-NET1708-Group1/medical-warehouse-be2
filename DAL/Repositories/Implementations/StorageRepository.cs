using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class StorageRepository : IStorageRepository
    {
        private readonly AppDbContext _context;
        public StorageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Storage storage)
        {
            _context.Storages.Add(storage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var storage = await _context.Storages.FindAsync(id);
            if (storage != null)
            {
                _context.Storages.Remove(storage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Storage>> GetAllAsync()
        {
            return await _context.Storages
                .Include(s => s.StorageCategory)
                .ToListAsync();
        }

        public async Task<Storage?> GetByIdAsync(int id)
        {
            return await _context.Storages
                .Include(s => s.StorageCategory)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(Storage updatedStorage)
        {
            _context.Storages.Update(updatedStorage);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Storage>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Storages
                .Where(s => s.StorageCategoryId == categoryId)
                .ToListAsync();
        }
    }
}
