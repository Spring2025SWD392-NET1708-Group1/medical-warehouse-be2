using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface ILotRequestService
    {
        Task<IEnumerable<LotRequestViewDTO>> GetAllLotRequestsAsync();
        Task<LotRequestViewDTO?> GetLotRequestByIdAsync(Guid id);
        Task<LotRequestViewDTO> CreateLotRequestAsync(LotRequestCreateDTO lotRequestDTO);
        Task<bool> UpdateLotRequestAsync(Guid id, LotRequestUpdateDTO lotRequestDTO);
        Task<bool> DeleteLotRequestAsync(Guid id);
    }
}
