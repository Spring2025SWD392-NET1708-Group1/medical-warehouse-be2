using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrdersAsync();
        Task<OrderDTO?> GetOrderByIdAsync(Guid id);
        Task<OrderDTO> CreateOrderAsync(OrderDTO orderDTO);
        Task<bool> UpdateOrderAsync(Guid id, OrderDTO orderDTO);
        Task<bool> DeleteOrderAsync(Guid id);
    }
}
