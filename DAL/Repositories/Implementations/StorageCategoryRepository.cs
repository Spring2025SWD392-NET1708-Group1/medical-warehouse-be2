using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class StorageCategoryRepository : IStorageCategoryRepository
    {
        private readonly AppDbContext _context;
        public StorageCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(StorageCategory category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var storageCategory = await _context.StorageCategories.FindAsync(id);
            if (storageCategory != null)
            {
                _context.StorageCategories.Remove(storageCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StorageCategory>> GetAllAsync()
        {
            return await _context.StorageCategories.ToListAsync();
        }

        public async Task<StorageCategory?> GetByIdAsync(int id)
        {
            return await _context.StorageCategories.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task UpdateAsync(StorageCategory category)
        {
            _context.StorageCategories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
