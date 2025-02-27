using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/lot-request")]
    public class LotRequestController : ControllerBase
    {
        private readonly ILotRequestService _lotRequestService;
        public LotRequestController(ILotRequestService lotRequestService)
        {
            _lotRequestService = lotRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LotRequestViewDTO>>> GetAllLotRequests()
        {
            return Ok(await _lotRequestService.GetAllLotRequestsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LotRequestViewDTO>> GetLotRequestById(Guid id)
        {
            var request = await _lotRequestService.GetLotRequestByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLotRequest([FromBody] LotRequestCreateDTO request)
        {
            var createdRequest = await _lotRequestService.CreateLotRequestAsync(request);
            return CreatedAtAction(nameof(GetLotRequestById), new { id = createdRequest.LotRequestId }, createdRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLotRequest(Guid id, [FromBody] LotRequestUpdateDTO request)
        {
            var updatedItem = await _lotRequestService.UpdateLotRequestAsync(id, request);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLotRequest(Guid id)
        {
            var success = await _lotRequestService.DeleteLotRequestAsync(id);
            if (success == false) return NotFound();
            return NoContent();
        }
    }
}
