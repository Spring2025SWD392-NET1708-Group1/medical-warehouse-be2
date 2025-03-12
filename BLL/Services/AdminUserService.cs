using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _adminUserRepository;
        private readonly IMapper _mapper;

        public AdminUserService(IAdminUserRepository adminUserRepository, IMapper mapper)
        {
            _adminUserRepository = adminUserRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewDTO>> GetAllUsersAsync()
        {
            var users = await _adminUserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserViewDTO>>(users);
        }

        public async Task<UserViewDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _adminUserRepository.GetByIdAsync(id);
            return user != null ? _mapper.Map<UserViewDTO>(user) : null;
        }

        public async Task<UserViewDTO> CreateUserAsync(UserCreateDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.Id = Guid.NewGuid();

            await _adminUserRepository.AddAsync(userEntity);
            return _mapper.Map<UserViewDTO>(userEntity);
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserUpdateDTO userDTO)
        {
            var user = await _adminUserRepository.GetByIdAsync(id);
            if (user == null) return false;

            _mapper.Map(userDTO, user);
            await _adminUserRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _adminUserRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _adminUserRepository.DeleteAsync(id);
            return true;
        }
    }
}