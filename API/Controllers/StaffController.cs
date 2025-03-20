using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/staff")]
    public class StaffController : Controller
    {
        private readonly IUserService _userService;

        public StaffController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "ManagerOrStaff")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewDTO>>> GetAllStaff()
        {
            var staffUsers = await _userService.GetAllStaffAsync();
            if (staffUsers == null || !staffUsers.Any())
            {
                return NotFound("No staff found.");
            }
            return Ok(staffUsers);
        }

        [Authorize(Roles = "ManagerOrStaff")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserViewDTO>> GetStaffById(Guid id)
        {
            var user = await _userService.GetStaffByIdAsync(id);
            if (user == null)
            {
                return NotFound($"No staff found with id: {id}");
            }
            return Ok(user);
        }

        [Authorize(Roles = "ManagerOrStaff")]
        [HttpGet("search-staff-name")]
        public async Task<ActionResult<IEnumerable<UserViewDTO>>> GetStaffByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name query parameter is required.");
            }

            var staffUsers = await _userService.GetStaffByNameAsync(name);
            if (staffUsers == null || !staffUsers.Any())
            {
                return NotFound($"No staff found with name: {name}");
            }
            return Ok(staffUsers);
        }
    }
}
