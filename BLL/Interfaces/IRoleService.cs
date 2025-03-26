using Common.DTOs;

namespace Common.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleViewDTO>> GetAllRolesAsync();
        Task<RoleViewDTO?> GetRoleByIdAsync(Guid id);
        Task<RoleViewDTO> CreateRoleAsync(RoleCreateDTO roleDTO);
        Task<bool> UpdateRoleAsync(Guid id, RoleUpdateDTO roleDTO);
        Task<bool> DeleteRoleAsync(Guid id);
    }
}
