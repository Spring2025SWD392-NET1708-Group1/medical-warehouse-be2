using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
        Task<RoleDTO?> GetRoleByIdAsync(int id);
        Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO);
        Task<bool> UpdateRoleAsync(int id, RoleDTO roleDTO);
        Task<bool> DeleteRoleAsync(int id);
    }
}
