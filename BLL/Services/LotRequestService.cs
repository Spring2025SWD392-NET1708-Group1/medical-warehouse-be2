using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LotRequestService : ILotRequestService
    {
        private readonly IMapper _mapper;
        private readonly ILotRequestRepository _lotRequestRepository;

        public LotRequestService(IMapper mapper, ILotRequestRepository lotRequestRepository)
        {
            _mapper = mapper;
            _lotRequestRepository = lotRequestRepository;
        }

        public async Task<IEnumerable<LotRequestViewDTO>> GetAllLotRequestsAsync()
        {
            var lotRequests = await _lotRequestRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<LotRequestViewDTO>>(lotRequests);
        }

        public async Task<LotRequestViewDTO?> GetLotRequestByIdAsync(Guid id)
        {
            var lotRequest = await _lotRequestRepository.GetByIdAsync(id);
            return _mapper.Map<LotRequestViewDTO?>(lotRequest);
        }

        public async Task<LotRequestViewDTO> CreateLotRequestAsync(LotRequestCreateDTO lotRequestDTO)
        {
            var lotRequest = _mapper.Map<LotRequest>(lotRequestDTO);
            await _lotRequestRepository.AddAsync(lotRequest);
            return _mapper.Map<LotRequestViewDTO>(lotRequest);
        }

        public async Task<bool> UpdateLotRequestAsync(Guid id, LotRequestUpdateDTO lotRequestDTO)
        {
            var lotRequest = await _lotRequestRepository.GetByIdAsync(id);
            if (lotRequest == null) return false;

            _mapper.Map(lotRequestDTO, lotRequest);
            await _lotRequestRepository.UpdateAsync(lotRequest);
            return true;
        }

        public async Task<bool> DeleteLotRequestAsync(Guid id)
        {
            var lotRequest = await _lotRequestRepository.GetByIdAsync(id);
            if (lotRequest == null) return false;

            await _lotRequestRepository.DeleteAsync(id);
            return true;
        }
    }
}
