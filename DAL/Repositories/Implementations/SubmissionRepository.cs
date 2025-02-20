using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly AppDbContext _context;

        public SubmissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Submission>> GetAllAsync()
        {
            return await _context.Submissions.Include(s => s.User).ToListAsync();
        }

        public async Task<Submission?> GetByIdAsync(Guid id)
        {
            return await _context.Submissions
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(Submission submission)
        {
            await _context.Submissions.AddAsync(submission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Submission submission)
        {
            _context.Submissions.Update(submission);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var submission = await _context.Submissions.FindAsync(id);
            if (submission != null)
            {
                _context.Submissions.Remove(submission);
                await _context.SaveChangesAsync();
            }
        }
    }
}
