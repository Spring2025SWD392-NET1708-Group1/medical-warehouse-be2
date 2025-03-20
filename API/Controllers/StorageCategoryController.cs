using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/storage-category")]
    public class StorageCategoryController : ControllerBase
    {
        private readonly IStorageCategoryService _storageCategoryService;
        public StorageCategoryController(IStorageCategoryService storageCategoryService)
        {
            _storageCategoryService = storageCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageCategoryViewDTO>>> GetAllStorageCategoriesAsync()
        {
            return Ok(await _storageCategoryService.GetAllStorageCategoriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StorageCategoryViewDTO>> GetStorageCategoryByIdAsync(int id)
        {
            var category = await _storageCategoryService.GetStorageCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorageAsync(StorageCategoryCreateDTO dto)
        {
            var category = await _storageCategoryService.CreateStorageCategoryAsync(dto);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStorageAsync(int id, StorageCategoryUpdateDTO dto)
        {
            var category = await _storageCategoryService.UpdateStorageCategoryAsync(id, dto);
            if (category == false) return NotFound();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageAsync(int id)
        {
            var category = await _storageCategoryService.DeleteStorageCategoryAsync(id);
            if (category == false) return NotFound();
            return NoContent();
        }
    }
}
