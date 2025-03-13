using Microsoft.AspNetCore.Mvc;
using BLL.Interfaces;
using BLL.DTOs;

namespace API.Controllers
{
    [Route("api/admin/users")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserService _adminUserService;

        public AdminUserController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewDTO>>> GetAllUsers()
        {
            var users = await _adminUserService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewDTO>> GetUserById(Guid id)
        {
            var user = await _adminUserService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewDTO>> CreateUser([FromBody] UserCreateDTO userDTO)
        {
            var user = await _adminUserService.CreateUserAsync(userDTO);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateDTO userDTO)
        {
            var success = await _adminUserService.UpdateUserAsync(id, userDTO);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var success = await _adminUserService.DeleteUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}