using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleViewDTO> CreateRoleAsync(RoleCreateDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            role.Id = Guid.NewGuid();

            await _roleRepository.AddAsync(role);
            return _mapper.Map<RoleViewDTO>(role);
        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return false;
            await _roleRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<RoleViewDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleViewDTO>>(roles);
        }

        public async Task<RoleViewDTO?> GetRoleByIdAsync(Guid id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return role != null ? _mapper.Map<RoleViewDTO>(role) : null;
        }

        public async Task<bool> UpdateRoleAsync(Guid id, RoleUpdateDTO roleDTO)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null) return false;

            _mapper.Map(roleDTO, role);
            await _roleRepository.UpdateAsync(role);
            return true;
        }
    }
}
