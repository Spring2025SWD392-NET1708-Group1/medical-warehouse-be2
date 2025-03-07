using Common.Enums;
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
                .ToListAsync();
        }

        // Fetch a single item with category and storage details
        public async Task<Item?> GetByIdWithCategoryAndStorageAsync(Guid id)
        {
            return await _context.Items
                .Include(i => i.ItemCategory)
                .FirstOrDefaultAsync(i => i.Id == id);
        }


        public async Task<IEnumerable<LotRequest>> GetExpiredItemsByDateAsync(DateTime date)
        {
            return await _context.LotRequests
                .Include(lr => lr.Item)
                .Include(lr => lr.Item.ItemCategory)
                .Include(lr => lr.Storage)
                .Include(lr => lr.User)
                .Where(lr => lr.ExpiryDate.Date < date.Date)
                .Where(lr => lr.Status == LotRequestEnums.Approved)
                .ToListAsync();
        }
    }
}
