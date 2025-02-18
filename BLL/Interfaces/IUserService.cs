using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> GetUserByIdAsync(Guid id);
        Task<UserDTO> CreateUserAsync(UserDTO userDTO);
        Task<bool> UpdateUserAsync(Guid id, UserDTO userDTO);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
