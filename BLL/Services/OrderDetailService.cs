using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetailViewDTO> CreateOrderDetail(OrderDetailCreateDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            await _orderDetailRepository.AddAsync(orderDetail);
            return _mapper.Map<OrderDetailViewDTO>(orderDetail);
        }

        public async Task<bool> DeleteOrderDetail(Guid id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail == null) return false;

            await _orderDetailRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<OrderDetailViewDTO>> GetAllOrderDetails()
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDetailViewDTO>>(orderDetails);
        }

        public async Task<OrderDetailViewDTO?> GetOrderDetailById(Guid id)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            return orderDetail != null ? _mapper.Map<OrderDetailViewDTO>(orderDetail) : null;
        }

        public async Task<bool> UpdateOrderDetail(Guid id, OrderDetailUpdateDTO orderDetailDTO)
        {
            var orderDetail = await _orderDetailRepository.GetByIdAsync(id);
            if (orderDetail == null) return false;

            _mapper.Map(orderDetailDTO, orderDetail);
            await _orderDetailRepository.UpdateAsync(orderDetail);
            return true;
        }
    }
}
