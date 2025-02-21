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

        public async Task<IEnumerable<OrderViewDTO>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Item)
                .Include(o => o.User)
                .ToListAsync();
            return _mapper.Map<IEnumerable<OrderViewDTO>>(orders);
        }

        public async Task<OrderViewDTO?> GetOrderByIdAsync(Guid id)
        {
            var order = await _context.Orders.Include(o => o.OrderDetails).FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<OrderViewDTO>(order);
        }

        public async Task<OrderViewDTO> CreateOrderAsync(OrderCreateDTO orderDTO)
        {
            var orderEntity = _mapper.Map<Order>(orderDTO);
            orderEntity.OrderDate = DateTime.UtcNow;
            orderEntity.Status = Common.Enums.OrderStatus.Pending;
            // Calculate the TotalPrice based on the OrderDetails
            decimal totalPrice = 0;

            foreach (var detail in orderDTO.OrderDetails)
            {
                totalPrice += detail.Quantity * detail.Price; // Calculate price for each OrderDetail
            }
            orderEntity.TotalPrice = totalPrice; 

            await _context.Orders.AddAsync(orderEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderViewDTO>(orderEntity);
        }

        public async Task<bool> UpdateOrderAsync(Guid id, OrderUpdateDTO orderDTO)
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

        public async Task<IEnumerable<OrderDetailViewDTO>> GetOrderDetailsAsync(Guid id)
        {
            var orderDetails = await _context.OrderDetails.Where(od => od.OrderId == id).ToListAsync();
            return _mapper.Map<IEnumerable<OrderDetailViewDTO>>(orderDetails);
        }
    }
}
