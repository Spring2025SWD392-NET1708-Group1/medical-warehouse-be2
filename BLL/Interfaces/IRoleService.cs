using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleByIdAsync(Guid id);
        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO);
        Task<bool> UpdateRoleAsync(Guid id, RoleDTO roleDTO);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
