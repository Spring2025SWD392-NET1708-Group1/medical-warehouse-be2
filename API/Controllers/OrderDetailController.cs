using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/order-detail")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetailCreateDTO dto)
        {
            var orderDetail = await _orderDetailService.CreateOrderDetail(dto);
            return CreatedAtAction(nameof(CreateOrderDetail), new { id = orderDetail.OrderId }, orderDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail(Guid id, [FromBody] OrderDetailUpdateDTO dto)
        {
            var updatedOrderDetail = await _orderDetailService.UpdateOrderDetail(id, dto);
            if (updatedOrderDetail == false) return NotFound();
            return Ok(updatedOrderDetail);

        }
    }
}
