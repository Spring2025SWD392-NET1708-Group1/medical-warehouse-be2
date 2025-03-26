using Common.DTOs;

namespace Common.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewDTO>> GetAllUsersAsync();
        Task<UserViewDTO?> GetUserByIdAsync(Guid id);
        Task<UserViewDTO> CreateUserAsync(UserCreateDTO userDTO);
        Task<bool> UpdateUserAsync(Guid id, UserUpdateDTO userDTO);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserViewDTO?> GetUserByEmailAsync(string email);
    }
}
