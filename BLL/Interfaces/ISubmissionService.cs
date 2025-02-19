using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
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
