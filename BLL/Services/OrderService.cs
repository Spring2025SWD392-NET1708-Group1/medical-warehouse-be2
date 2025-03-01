using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using Common.Enums;
using DAL.Entities;
using DAL.Repositories.Interfaces;

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

        public async Task<IEnumerable<OrderViewDTO>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderViewDTO>>(orders);
        }

        public async Task<OrderViewDTO?> GetOrderByIdAsync(Guid id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order != null ? _mapper.Map<OrderViewDTO>(order) : null;
        }

        public async Task<OrderViewDTO> CreateOrderAsync(OrderCreateDTO orderDTO)
        {
            var orderEntity = _mapper.Map<Order>(orderDTO);
            orderEntity.Id = Guid.NewGuid();
            orderEntity.Status = OrderStatus.Pending;
            decimal totalPrice = 0;
            foreach (var details in orderEntity.OrderDetails)
            {
                totalPrice += details.Price;
            }
            orderEntity.TotalPrice = totalPrice;
            await _orderRepository.AddAsync(orderEntity);
            return _mapper.Map<OrderViewDTO>(orderEntity);
        }

        public async Task<bool> UpdateOrderAsync(Guid id, OrderUpdateDTO orderDTO)
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

        // public async Task<IEnumerable<OrderDetailViewDTO>> GetOrderDetailsAsync(Guid id)
        // {
        //     var orderDetails = await _context.OrderDetails.Where(od => od.OrderId == id).ToListAsync();
        //     return _mapper.Map<IEnumerable<OrderDetailViewDTO>>(orderDetails);
        // }
    }
}
