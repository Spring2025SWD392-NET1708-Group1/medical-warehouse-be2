using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class ItemCategoryRepository : IItemCategoryRepository
    {
        private readonly AppDbContext _context;

        public ItemCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemCategory>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<ItemCategory?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(ItemCategory category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItemCategory category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
