using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IOrderDetailService
    {
        Task<OrderDetailViewDTO> CreateOrderDetail(OrderDetailCreateDTO orderDetailDTO);
        Task<bool> DeleteOrderDetail(Guid id);
        Task<bool> UpdateOrderDetail(Guid id, OrderDetailUpdateDTO orderDetailDTO);
        Task<OrderDetailViewDTO?> GetOrderDetailById(Guid id);
        Task<IEnumerable<OrderDetailViewDTO>> GetAllOrderDetails();
    }
}
