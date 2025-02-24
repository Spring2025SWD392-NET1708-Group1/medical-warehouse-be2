using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ILotRequestRepository
    {
        Task<IEnumerable<LotRequest>> GetAllAsync();
        Task<LotRequest?> GetByIdAsync(Guid id);
        Task AddAsync(LotRequest lotRequest);
        Task UpdateAsync(LotRequest lotRequest);
        Task DeleteAsync(Guid id);
    }
}
