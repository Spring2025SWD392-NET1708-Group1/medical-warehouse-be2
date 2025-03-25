using AutoMapper;
using Common.DTOs;
using Common.Interfaces;
using Common.Utils;
using Common.Enums;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class StockInRequestService : IStockInRequestService
    {
        private readonly IStockInRequestRepository _repository;
        private readonly IMapper _mapper;
        private readonly JwtUtils _jwtUtils;
        public StockInRequestService(IStockInRequestRepository repository, IMapper mapper, JwtUtils jwtUtils)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }
        public async Task<StockInRequestViewDTO> CreateStockInRequestAsync(StockInRequestCreateDTO dto)
        {
            var user = await _jwtUtils.GetUserFromToken();
            var request = _mapper.Map<StockInRequest>(dto);

            request.Id = Guid.NewGuid();
            request.UserId = user.Id;
            request.Status = StockInRequestStatus.Pending;
            request.PaymentStatus = TransactionStatus.Pending;
            request.CreatedAt = DateTime.UtcNow;

            await _repository.CreateAsync(request);
            return _mapper.Map<StockInRequestViewDTO>(request);
        }

        public async Task<bool> DeleteStockInRequestAsync(Guid id)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return false;
            await _repository.DeleteAsync(request);
            return true;
            
        }

        public async Task<IEnumerable<StockInRequestViewDTO>> GetStockInRequestsAsync()
        {
            var requests = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StockInRequestViewDTO>>(requests);
        }

        public async Task<IEnumerable<StockInRequestViewDTO>> GetAllStockInRequestsByUserIdAsync()
        {
            var user = await _jwtUtils.GetUserFromToken();
            var requests = await _repository.GetAllByUserIdAsync(user.Id);
            return _mapper.Map<IEnumerable<StockInRequestViewDTO>>(requests);
        }

        public async Task<StockInRequestViewDTO> GetStockInRequestByIdAsync(Guid id)
        {
            var requests = await _repository.GetByIdAsync(id);
            return _mapper.Map<StockInRequestViewDTO>(requests);
        }

        public async Task<bool> UpdateStockInRequestAsync(Guid id, StockInRequestUpdateDTO dto)
        {
            var request = await _repository.GetByIdAsync(id);
            if (request == null) return false;

            Console.WriteLine($"Before update - RequestStatus: {request.Status}");
            _mapper.Map(dto, request);
            Console.WriteLine($"After update - RequestStatus: {request.Status}");

            await _repository.UpdateAsync(request);
            return true;
        }

    }
}
