using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewDTO>> GetAllOrdersAsync();
        Task<OrderViewDTO?> GetOrderByIdAsync(Guid id);
        // Task<IEnumerable<OrderDetailViewDTO>> GetOrderDetailsAsync(Guid id);
        Task<OrderViewDTO> CreateOrderAsync(OrderCreateDTO dto);
        Task<bool> UpdateOrderAsync(Guid id, OrderUpdateDTO dto);
        Task<bool> DeleteOrderAsync(Guid id);
    }
}
