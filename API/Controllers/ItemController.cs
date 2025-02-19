using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return Ok(await _itemService.GetAllItemsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemViewDTO>> GetItemById(Guid id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemCreateDTO itemDto)
        {
            var createdItem = await _itemService.CreateItemAsync(itemDto);
            return CreatedAtAction(nameof(GetItemById), new { id = createdItem.Id }, createdItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] ItemUpdateDTO itemDto)
        {
            var updatedItem = await _itemService.UpdateItemAsync(id, itemDto);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var success = await _itemService.DeleteItemAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
