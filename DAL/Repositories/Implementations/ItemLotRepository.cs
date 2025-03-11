using Common.Enums;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class ItemLotRepository : IItemLotRepository
    {
        private readonly AppDbContext _context;
        public ItemLotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ItemLot itemLot)
        {
            await _context.ItemLots.AddAsync(itemLot);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = await _context.ItemLots.FindAsync(id);
            if (request != null)
            {
                _context.ItemLots.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ItemLot>> GetAllAsync()
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .ThenInclude(i => i.ItemCategory)
                .Include(il => il.Item)
                .ThenInclude(i => i.User)
                .Include(il => il.Storage)
                .ToListAsync();
        }

        public async Task<ItemLot?> GetByIdAsync(Guid id)
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .ThenInclude(i => i.ItemCategory)
                .Include(il => il.Item)
                .ThenInclude(i => i.User)
                .Include(il => il.Storage)
                .FirstOrDefaultAsync(il => il.ItemLotId == id);
        }

        public async Task UpdateAsync(ItemLot lotRequest)
        {
            _context.ItemLots.Update(lotRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemLot>> GetExpiredItemsByDateAsync(DateTime date)
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .Include(il => il.Item.ItemCategory)
                .Include(il => il.Item.User)
                .Include(il => il.Storage)
                .Where(il => il.ExpiryDate.Date < date.Date)
                .Where(il => il.Status == LotStatus.InStorage)
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemLot>> GetByStorageIdAsync(int storageId)
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .Include(il => il.Item.ItemCategory)
                .Include(il => il.Item.User)
                .Include(il => il.Storage)
                .Where(il => il.StorageId == storageId)
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemLot>> GetByItemIdAsync(Guid itemId)
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .Include(il => il.Item.ItemCategory)
                .Include(il => il.Item.User)
                .Include(il => il.Storage)
                .Where(il => il.ItemId == itemId)
                .ToListAsync();

        }

        public async Task<IEnumerable<ItemLot>> GetByStorageIdForStaffAsync(int storageId)
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .Include(il => il.Item.ItemCategory)
                .Include(il => il.Item.User)
                .Include(il => il.Storage)
                .Where(il => il.StorageId == storageId
                && (il.Status == LotStatus.NeedDisposing
                || il.Status == LotStatus.Rejected
                || il.Status == LotStatus.ToBeImport))
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemLot>> GetCreateLotRequestAsync()
        {
            return await _context.ItemLots
                .Include(il => il.Item)
                .Include(il => il.Item.ItemCategory)
                .Include(il => il.Item.User)
                .Include(il => il.Storage)
                .Where(il=>il.Status == LotStatus.Pending)
                .ToListAsync();
        }
    }
}
