using Common.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IStockInRequestService
    {
        Task<IEnumerable<StockInRequestViewDTO>> GetStockInRequestsAsync();
        Task<StockInRequestViewDTO> GetStockInRequestByIdAsync(Guid id);
        Task<IEnumerable<StockInRequestViewDTO>> GetAllStockInRequestsByUserIdAsync();
        Task<StockInRequestViewDTO> CreateStockInRequestAsync(StockInRequestCreateDTO stockInRequest);
        Task<bool> UpdateStockInRequestAsync(Guid id, StockInRequestUpdateDTO stockInRequest);
        Task<bool> DeleteStockInRequestAsync(Guid id);
    }
}
