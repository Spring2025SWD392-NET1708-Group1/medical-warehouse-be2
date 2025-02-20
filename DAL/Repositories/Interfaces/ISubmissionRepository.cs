using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetAllAsync();
        Task<Submission?> GetByIdAsync(Guid id);
        Task AddAsync(Submission submission);
        Task UpdateAsync(Submission submission);
        Task DeleteAsync(Guid id);
    }
}
