using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/stock-in-request")]
    public class StockInRequestController : ControllerBase
    {
        private readonly IStockInRequestService _service;
        public StockInRequestController(IStockInRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<IEnumerable<StockInRequestViewDTO>>> GetStockInRequestsAsync()
        {
            return Ok(await _service.GetStockInRequestsAsync());
        } 

        [HttpGet("user")]
        [Authorize(Roles = "Supplier")]
        public async Task<ActionResult<IEnumerable<StockInRequestViewDTO>>> GetAllStockInRequestsByUserIdAsync()
        {
            return Ok(await _service.GetAllStockInRequestsByUserIdAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockInRequestViewDTO>> GetStockInRequestByIdAsync(Guid id)
        {
            var request = await _service.GetStockInRequestByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        [Authorize(Roles = "Supplier")]
        public async Task<ActionResult> CreateStockInRequestAsync([FromBody] StockInRequestCreateDTO request)
        {
            var createdRequest = await _service.CreateStockInRequestAsync(request);
            return Ok(createdRequest);

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Supplier, Staff, Manager")]
        public async Task<ActionResult> UpdateStockInRequestAsync(Guid id, [FromBody] StockInRequestUpdateDTO request)
        {
            var updatedItem = await _service.UpdateStockInRequestAsync(id, request);    
            if(updatedItem == false) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStockInRequestAsync(Guid id)
        {
            var deletedItem = await _service.DeleteStockInRequestAsync(id);
            if (deletedItem == false) return NotFound();
            return NoContent();
        }
    }
}
