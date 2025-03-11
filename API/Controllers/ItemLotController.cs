using BLL.DTOs;
using BLL.Interfaces;
using BLL.Services;
using BLL.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/item-lots")]

    public class ItemLotController : ControllerBase
    {
        private readonly IItemLotService _itemLotService;
        private readonly JwtUtils _jwtUtils;
        public ItemLotController(IItemLotService itemLotService, JwtUtils jwtUtils)
        {
            _itemLotService = itemLotService;
            _jwtUtils = jwtUtils;
        }

        [Authorize(Policy = "ManagerOrStaff")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemLotViewDTO>>> GetAllItemLots()
        {
            return Ok(await _itemLotService.GetAllItemLotsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemLotViewDTO>> GetItemLotById(Guid id)
        {
            var request = await _itemLotService.GetItemLotByIdAsync(id);
            if (request == null) return NotFound();
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItemLot([FromBody] ItemLotCreateDTO request)
        {
            var createdRequest = await _itemLotService.CreateItemLotAsync(request);
            return CreatedAtAction(nameof(GetItemLotById), new { id = createdRequest.ItemLotId }, createdRequest);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "ManagerOrStaff")]
        public async Task<ActionResult> UpdateItemLot(Guid id, [FromBody] ItemLotUpdateDTO request)
        {
            var updatedItem = await _itemLotService.UpdateItemLotAsync(id, request);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemLot(Guid id)
        {
            var success = await _itemLotService.DeleteItemLotAsync(id);
            if (success == false) return NotFound();
            return NoContent();
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("admin/{id}")]
        public async Task<ActionResult> UpdateItemLotAdmin(Guid id, [FromBody] ItemLotAdminUpdateDTO request)
        {
            var updatedItem = await _itemLotService.UpdatItemLotAdminAsync(id, request);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }

        [Authorize(Policy = "Staff")]
        [HttpGet("expiring-by/{expiryDate}")]
        public async Task<ActionResult<IEnumerable<ItemViewDTO>>> GetItemsExpiringByDate(DateTime expiryDate)
        {
            var items = await _itemLotService.GetExpiredItemsByDateAsync(expiryDate);
            return Ok(items);
        }

        [Authorize(Policy = "ManagerOrStaff")]
        [HttpGet("storage/{storageId}")]
        public async Task<ActionResult<IEnumerable<ItemLotViewDTO>>> GetItemLotsByStorage(int storageId)
        {
            var itemLots = await _itemLotService.GetItemLotByStorageAsync(storageId);
            return Ok(itemLots);
        }

        [Authorize(Policy = "ManagerOrStaff")]
        [HttpGet("item/{itemId}")]
        public async Task<ActionResult<IEnumerable<ItemLotViewDTO>>> GetItemLotsByItem(Guid itemId)
        {
            var itemLots = await _itemLotService.GetByItemIdAsync(itemId);
            return Ok(itemLots);
        }
        [Authorize(Policy = "ManagerOrStaff")]
        [HttpGet("storage/requests")]
        public async Task<ActionResult<IEnumerable<ItemLotViewDTO>>> GetByStorageIdForStaffAsync()
        {
            var itemLots = await _itemLotService.GetByStorageIdForStaffAsync();
            return Ok(itemLots);
        }

        [Authorize(Policy = "Manager")]
        [HttpGet("create-requests")]
        public async Task<ActionResult<IEnumerable<ItemLotViewDTO>>> GetCreateLotRequestsAsync()
        {
            var itemLots = await _itemLotService.GetLotCreateRequestAsync();
            return Ok(itemLots);
        }
    }
}
