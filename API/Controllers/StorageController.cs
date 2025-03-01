using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/storage")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;
        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageViewDTO>>> GetAllStoragesAsync()
        {
            return Ok(await _storageService.GetAllStoragesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StorageViewDTO>> GetStorageByIdAsync(int id)
        {
            var storage = await _storageService.GetStorageByIdAsync(id);
            if (storage == null) return NotFound();
            return Ok(storage);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<StorageViewDTO>>> GetStorageByCategoryIdAsync(int categoryId)
        {
            return Ok(await _storageService.GetStoragesByCategoryIdAsync(categoryId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStorageAsync(StorageCreateDTO dto)
        {
            var storage = await _storageService.CreateStorageAsync(dto);
            return CreatedAtAction(nameof(CreateStorageAsync), storage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStorageAsync(int id,  StorageUpdateDTO dto)
        {
            var storage = await _storageService.UpdateStorageAsync(id, dto);
            if(storage == false) return NotFound();
            return Ok(storage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageAsync(int id)
        {
            var storage = await _storageService.DeleteStorageAsync(id);
            if (storage == false) return NotFound();
            return NoContent();
        }
    }
}
