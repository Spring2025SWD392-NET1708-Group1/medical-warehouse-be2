using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/item-category")]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemCategoryDTO>>> GetAllItemCategories()
        {
            return Ok(await _itemCategoryService.GetAllCategoriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemViewDTO>> GetItemById(Guid id)
        {
            var item = await _itemCategoryService.GetCategoryByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] ItemCategoryDTO dto)
        {
            var category = await _itemCategoryService.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(GetItemById), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] ItemCategoryDTO dto)
        {
            var updatedItem = await _itemCategoryService.UpdateCategoryAsync(id, dto);
            if (updatedItem == false) return NotFound();
            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var success = await _itemCategoryService.DeleteCategoryAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
