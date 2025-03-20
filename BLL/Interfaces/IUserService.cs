using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewDTO>> GetAllUsersAsync();
        Task<UserViewDTO?> GetUserByIdAsync(Guid id);
        Task<UserViewDTO> CreateUserAsync(UserCreateDTO userDTO);
        Task<bool> UpdateUserAsync(Guid id, UserUpdateDTO userDTO);
        Task<bool> DeleteUserAsync(Guid id);
        Task<UserViewDTO?> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserViewDTO>> GetAllStaffAsync();
        Task<UserViewDTO?> GetStaffByIdAsync(Guid id);
        Task<IEnumerable<UserViewDTO>> GetStaffByNameAsync(string name);
    }
}
