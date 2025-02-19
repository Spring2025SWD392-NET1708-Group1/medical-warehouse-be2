using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public SubmissionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubmissionViewDTO> CreateSubmissionAsync(SubmissionCreateDTO dto)
        {
            var submission = _mapper.Map<Submission>(dto);
            submission.Id = Guid.NewGuid();
            submission.CreatedDate = DateTime.UtcNow;

            await _context.Submissions.AddAsync(submission);
            await _context.SaveChangesAsync();
            return _mapper.Map<SubmissionViewDTO>(submission);
        }

        public async Task<bool> DeleteSubmissionAsync(Guid id)
        {
            var submission = await _context.Submissions.FirstOrDefaultAsync(s => s.Id == id);
            if (submission == null) return false;

            _context.Submissions.Remove(submission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SubmissionViewDTO>> GetAllSubmissionsAsync()
        {
            var submissions = await _context.Submissions.Include(s => s.User).ToListAsync();
            return _mapper.Map<IEnumerable<SubmissionViewDTO>>(submissions);
        }

        public async Task<SubmissionViewDTO?> GetSubmissionByIdAsync(Guid id)
        {
            var submission = await _context.Submissions
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == id);

            return _mapper.Map<SubmissionViewDTO?>(submission);
        }

        public async Task<bool> UpdateSubmissionAsync(Guid id, SubmissionUpdateDTO dto)
        {
            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null) return false;

            _mapper.Map(dto, submission);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
