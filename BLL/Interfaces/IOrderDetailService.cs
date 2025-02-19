using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailViewDTO>> GetAllOrderDetails();
        Task<OrderDetailViewDTO?> GetOrderDetail(Guid id);
        Task<OrderDetailViewDTO> CreateOrderDetail(OrderDetailCreateDTO orderDetailDTO);
        Task<bool> DeleteOrderDetail(Guid id);
        Task<bool> UpdateOrderDetail(Guid id, OrderDetailUpdateDTO orderDetailDTO);
    }
}
