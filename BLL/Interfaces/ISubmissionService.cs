using Common.DTOs;

namespace Common.Interfaces
{
    public interface ISubmissionService
    {
        Task<IEnumerable<SubmissionViewDTO>> GetAllSubmissionsAsync();
        Task<SubmissionViewDTO?> GetSubmissionByIdAsync(Guid id);
        Task<SubmissionViewDTO> CreateSubmissionAsync(SubmissionCreateDTO dto);
        Task<bool> UpdateSubmissionAsync(Guid id, SubmissionUpdateDTO dto);
        Task<bool> DeleteSubmissionAsync(Guid id);
    }
}
