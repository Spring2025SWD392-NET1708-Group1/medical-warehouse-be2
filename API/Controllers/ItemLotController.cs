using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/item-lots")]
    public class ItemLotController : ControllerBase
    {
        private readonly IItemLotService _itemLotService;
        public ItemLotController(IItemLotService itemLotService)
        {
            _itemLotService = itemLotService;
        }

        [Authorize(Policy = "ManagerPolicy")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLotViewDTO>>> GetAllLotRequests()
        {
            return Ok(await _itemLotService.GetAllItemLotsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLotViewDTO>> GetLotRequestById(Guid id)
        {
            var request = await _itemLotService.GetItemLotByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLotRequest([FromBody] ItemLotCreateDTO request)
        {
            var createdRequest = await _itemLotService.CreateItemLotAsync(request);
            return CreatedAtAction(nameof(GetLotRequestById), new { id = createdRequest.ItemLotId }, createdRequest);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLotRequest(Guid id, [FromBody] ItemLotUpdateDTO request)
        {
            var updatedItem = await _itemLotService.UpdateItemLotAsync(id, request);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLotRequest(Guid id)
        {
            var success = await _itemLotService.DeleteItemLotAsync(id);
            if (success == false) return NotFound();
            return NoContent();
        }

        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("admin/{id}")]
        public async Task<ActionResult> UpdateLotRequestAdmin(Guid id, [FromBody] ItemLotAdminUpdateDTO request)
        {
            var updatedItem = await _itemLotService.UpdatItemLotAdminAsync(id, request);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }


        [HttpGet("expiring-by/{expiryDate}")]
        public async Task<ActionResult<IEnumerable<ItemViewDTO>>> GetItemsExpiringByDate(DateTime expiryDate)
        {
            var items = await _itemLotService.GetExpiredItemsByDateAsync(expiryDate);
            return Ok(items);
        }
    }
}
