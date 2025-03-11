using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Utils;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IAuthService authService, IUserRepository userRepository, IMapper mapper)
        {
            _authService = authService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserViewDTO>>(users);
        }

        public async Task<UserViewDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? _mapper.Map<UserViewDTO>(user) : null;
        }

        public async Task<UserViewDTO?> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return user != null ? _mapper.Map<UserViewDTO>(user) : null;
        }

        public async Task<UserViewDTO> CreateUserAsync(UserCreateDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.Id = Guid.NewGuid();
            userEntity.ActivationToken = Guid.NewGuid();
            userEntity.PasswordHash = PasswordUtils.HashPassword(userDTO.Password);
            await _userRepository.AddAsync(userEntity);
            return _mapper.Map<UserViewDTO>(userEntity);
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserUpdateDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            _mapper.Map(userDTO, user);
            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }

    }
}
