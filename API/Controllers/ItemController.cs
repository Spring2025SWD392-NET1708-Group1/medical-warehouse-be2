using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemViewDTO>>> GetAllItems()
        {
            var items = await _itemService.GetAllItemsWithDetailsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemViewDTO>> GetItemById(Guid id)
        {
            var item = await _itemService.GetItemByIdWithDetailsAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpGet("expiry-range")]
        public async Task<ActionResult<IEnumerable<ItemViewDTO>>> GetItemsByExpiryRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
                return BadRequest("Start date cannot be after end date.");

            var items = await _itemService.GetItemsByExpiryRangeAsync(startDate, endDate);
            if (!items.Any())
                return NotFound("No items found within the given expiry range.");

            return Ok(items);
        }


        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemCreateDTO itemDto)
        {
            if (itemDto == null) return BadRequest("Invalid item data.");

            var createdItem = await _itemService.CreateItemAsync(itemDto);
            return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] ItemUpdateDTO itemDto)
        {
            if (itemDto == null) return BadRequest("Invalid update data.");

            var updatedItem = await _itemService.UpdateItemAsync(id, itemDto);
            if (!updatedItem) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var success = await _itemService.DeleteItemAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("expiring-by/{expiryDate}")]
        public async Task<ActionResult<IEnumerable<ItemViewDTO>>> GetItemsExpiringByDate(DateTime expiryDate)
        {
            var items = await _itemService.GetItemsExpiringByDateAsync(expiryDate);
            return Ok(items);
        }
    }
}
