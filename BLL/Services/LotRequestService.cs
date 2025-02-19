using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LotRequestService : ILotRequestService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LotRequestService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LotRequestViewDTO>> GetAllLotRequestsAsync()
        {
            var lotRequests = await _context.LotRequests.ToListAsync();
            return _mapper.Map<IEnumerable<LotRequestViewDTO>>(lotRequests);
        }

        public async Task<LotRequestViewDTO?> GetLotRequestByIdAsync(Guid id)
        {
            var lotRequest = await _context.LotRequests.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<LotRequestViewDTO?>(lotRequest);
        }

        public async Task<LotRequestViewDTO> CreateLotRequestAsync(LotRequestCreateDTO lotRequestDTO)
        {
            var lotRequest = _mapper.Map<LotRequest>(lotRequestDTO);
            await _context.LotRequests.AddAsync(lotRequest);
            await _context.SaveChangesAsync();
            return _mapper.Map<LotRequestViewDTO>(lotRequest);
        }

        public async Task<bool> UpdateLotRequestAsync(Guid id, LotRequestUpdateDTO lotRequestDTO)
        {
            var lotRequest = await _context.LotRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (lotRequest == null) return false;

            _mapper.Map(lotRequestDTO, lotRequest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLotRequestAsync(Guid id)
        {
            var lotRequest = await _context.LotRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (lotRequest == null) return false;

            _context.LotRequests.Remove(lotRequest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
