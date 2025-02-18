using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO?> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderDTO orderDTO)
        {
            var orderEntity = _mapper.Map<Order>(orderDTO);
            _context.Orders.Add(orderEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(orderEntity);
        }

        public async Task<bool> UpdateOrderAsync(Guid id, OrderDTO orderDTO)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return false;

            _mapper.Map(orderDTO, order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
