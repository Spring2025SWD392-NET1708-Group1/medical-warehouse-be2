using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public SubmissionService(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository;
            _mapper = mapper;
        }

        public async Task<SubmissionViewDTO> CreateSubmissionAsync(SubmissionCreateDTO dto)
        {
            var submission = _mapper.Map<Submission>(dto);
            submission.Id = Guid.NewGuid();
            submission.CreatedDate = DateTime.UtcNow;

            await _submissionRepository.AddAsync(submission);
            return _mapper.Map<SubmissionViewDTO>(submission);
        }

        public async Task<bool> DeleteSubmissionAsync(Guid id)
        {
            var submission = await _submissionRepository.GetByIdAsync(id);
            if (submission == null) return false;

            await _submissionRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<SubmissionViewDTO>> GetAllSubmissionsAsync()
        {
            var submissions = await _submissionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubmissionViewDTO>>(submissions);
        }

        public async Task<SubmissionViewDTO?> GetSubmissionByIdAsync(Guid id)
        {
            var submission = await _submissionRepository.GetByIdAsync(id);
            return submission != null ? _mapper.Map<SubmissionViewDTO>(submission) : null;
        }

        public async Task<bool> UpdateSubmissionAsync(Guid id, SubmissionUpdateDTO dto)
        {
            var submission = await _submissionRepository.GetByIdAsync(id);
            if (submission == null) return false;

            _mapper.Map(dto, submission);
            await _submissionRepository.UpdateAsync(submission);
            return true;
        }
    }
}
