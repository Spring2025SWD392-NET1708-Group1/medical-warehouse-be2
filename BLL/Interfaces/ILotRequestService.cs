using BLL.DTOs;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface ILotRequestService
    {
        Task<IEnumerable<LotRequestViewDTO>> GetAllLotRequestsAsync();
        Task<LotRequestViewDTO?> GetLotRequestByIdAsync(Guid id);
        Task<LotRequestViewDTO> CreateLotRequestAsync(LotRequestCreateDTO lotRequestDTO);
        Task<bool> UpdateLotRequestAsync(Guid id, LotRequestUpdateDTO lotRequestDTO);
        Task<bool> UpdateLotRequestAdminAsync(Guid id, LotRequestAdminUpdateDTO lotRequestDTO);
        Task<bool> DeleteLotRequestAsync(Guid id);
    }
}
