using Common.DTOs;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleViewDTO>>> GetRoles()
        {
            return Ok(await _roleService.GetAllRolesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleViewDTO>> GetRoleById(Guid id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateDTO dto)
        {
            var role = await _roleService.CreateRoleAsync(dto);
            return CreatedAtAction(nameof(CreateRole), role);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(Guid id, RoleUpdateDTO dto)
        {
            var role = await _roleService.UpdateRoleAsync(id, dto);
            if (!role) return NotFound();
            return Ok(role);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await _roleService.DeleteRoleAsync(id);
            if (!role) return NotFound();
            return Ok(role);
        }
    }
}
