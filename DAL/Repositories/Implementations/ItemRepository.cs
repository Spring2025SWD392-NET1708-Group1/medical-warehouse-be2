using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetByIdAsync(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }

        // Fetch items with category and storage details
        public async Task<IEnumerable<Item>> GetAllWithCategoryAndStorageAsync()
        {
            return await _context.Items
                .Include(i => i.ItemCategory)
                .Include(i => i.Storage)
                .ToListAsync();
        }

        // Fetch a single item with category and storage details
        public async Task<Item?> GetByIdWithCategoryAndStorageAsync(Guid id)
        {
            return await _context.Items
                .Include(i => i.ItemCategory)
                .Include(i => i.Storage)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // Fetch items that will expire by a given date
        public async Task<IEnumerable<Item>> GetItemsExpiringByDateAsync(DateTime expiryDate)
        {
            return await _context.Items
                .Where(i => i.ExpiryDate <= expiryDate)
                .Include(i => i.ItemCategory)
                .Include(i => i.Storage)
                .ToListAsync();
        }
        // Fetch items with the expiry time range
        public async Task<IEnumerable<Item>> GetItemsByExpiryRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Items
                .Where(item => item.ExpiryDate >= startDate && item.ExpiryDate <= endDate)
                .Include(i => i.ItemCategory)  // Include the related ItemCategory
                .Include(i => i.Storage)       // Include the related Storage
                .ToListAsync();
        }

    }
}
