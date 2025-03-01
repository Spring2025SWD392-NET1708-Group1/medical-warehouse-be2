using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class LotRequestRepository : ILotRequestRepository
    {
        private readonly AppDbContext _context;
        public LotRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LotRequest lotRequest)
        {
            await _context.LotRequests.AddAsync(lotRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var request = await _context.LotRequests.FindAsync(id);
            if (request != null)
            {
                _context.LotRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<LotRequest>> GetAllAsync()
        {
            return await _context.LotRequests
                .Include(lr => lr.Item)
                .ThenInclude(i => i.ItemCategory)
                .Include(lr => lr.User)
                .Include(lr => lr.Storage)
                .ToListAsync();
        }

        public async Task<LotRequest?> GetByIdAsync(Guid id)
        {
            return await _context.LotRequests
                .Include(lr => lr.Item)
                .ThenInclude(i => i.ItemCategory)
                .Include(lr => lr.User)
                .Include(lr => lr.Storage)
                .FirstOrDefaultAsync(x => x.LotRequestId == id);
        }

        public async Task UpdateAsync(LotRequest lotRequest)
        {
            _context.LotRequests.Update(lotRequest);
            await _context.SaveChangesAsync();
        }
    }
}
