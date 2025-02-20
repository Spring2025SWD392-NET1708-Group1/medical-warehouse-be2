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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order != null ? _mapper.Map<OrderDTO>(order) : null;
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderDTO orderDTO)
        {
            var orderEntity = _mapper.Map<Order>(orderDTO);
            await _orderRepository.AddAsync(orderEntity);
            return _mapper.Map<OrderDTO>(orderEntity);
        }

        public async Task<bool> UpdateOrderAsync(Guid id, OrderDTO orderDTO)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return false;

            _mapper.Map(orderDTO, order);
            await _orderRepository.UpdateAsync(order);
            return true;
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null) return false;

            await _orderRepository.DeleteAsync(id);
            return true;
        }
    }
}
