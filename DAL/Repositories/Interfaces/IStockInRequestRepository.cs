using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IStockInRequestRepository
    {
        Task<IEnumerable<StockInRequest>> GetAllAsync();
        Task<StockInRequest> GetByIdAsync(Guid id);
        Task<IEnumerable<StockInRequest>> GetAllByUserIdAsync(Guid userId);
        Task CreateAsync(StockInRequest stockInRequest);
        Task UpdateAsync(StockInRequest stockInRequest);
        Task DeleteAsync(StockInRequest stockInRequest);
    }
}
