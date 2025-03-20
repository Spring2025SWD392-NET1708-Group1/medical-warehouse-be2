using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Implementations
{
    public class StockInRequestRepository : IStockInRequestRepository
    {
        private readonly AppDbContext _context;
        public StockInRequestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(StockInRequest stockInRequest)
        {
            await _context.AddAsync(stockInRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(StockInRequest stockInRequest)
        {
            _context.Remove(stockInRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockInRequest>> GetAllAsync()
        {
            return await _context.StockInRequests
                .Include(s => s.User)
                .Include(s => s.Item)
                .ToListAsync();
        }

        public async Task<IEnumerable<StockInRequest>> GetAllByUserIdAsync(Guid userId)
        {
            return await _context.StockInRequests
                .Include(s => s.User)
                .Include(s => s.Item)
                .Where(s => userId == s.UserId)
                .ToListAsync();
        }

        public async Task<StockInRequest> GetByIdAsync(Guid id)
        {
            return await _context.StockInRequests
                .Include(s => s.User)
                .Include(s => s.Item)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task UpdateAsync(StockInRequest stockInRequest)
        {
            _context.Update(stockInRequest);
            await _context.SaveChangesAsync();
        }
    }

}
