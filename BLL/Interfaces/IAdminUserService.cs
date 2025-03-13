using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IAdminUserService
    {
        Task<IEnumerable<UserViewDTO>> GetAllUsersAsync();
        Task<UserViewDTO?> GetUserByIdAsync(Guid id);
        Task<UserViewDTO> CreateUserAsync(UserCreateDTO userDTO);
        Task<bool> UpdateUserAsync(Guid id, UserUpdateDTO userDTO);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
