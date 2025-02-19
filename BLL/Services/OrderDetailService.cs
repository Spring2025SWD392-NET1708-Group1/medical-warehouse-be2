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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderDetailService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDetailViewDTO> CreateOrderDetail(OrderDetailCreateDTO orderDetailDTO)
        {
            var orderDetail = _mapper.Map<OrderDetail>(orderDetailDTO);
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDetailViewDTO>(orderDetail);
        }

        public async Task<bool> DeleteOrderDetail(Guid id)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (orderDetail == null) return false;

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderDetailViewDTO>> GetAllOrderDetails()
        {
            var orderDetails = await _context.OrderDetails.ToListAsync();
            return _mapper.Map<IEnumerable<OrderDetailViewDTO>>(orderDetails);
        }

        public async Task<OrderDetailViewDTO?> GetOrderDetail(Guid id)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x=>x.Id == id);
            return _mapper.Map<OrderDetailViewDTO?>(orderDetail);
        }

        public async Task<bool> UpdateOrderDetail(Guid id, OrderDetailUpdateDTO orderDetailDTO)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (orderDetail == null) return false;

            _mapper.Map(orderDetailDTO, orderDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
