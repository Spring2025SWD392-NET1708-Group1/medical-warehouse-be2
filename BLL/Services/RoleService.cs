using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoleService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoleViewDTO> CreateRoleAsync(RoleCreateDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            role.Id = Guid.NewGuid();

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return _mapper.Map<RoleViewDTO>(role);

        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null) return false;
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoleViewDTO>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleViewDTO>>(roles);
        }

        public async Task<RoleViewDTO?> GetRoleByIdAsync(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return _mapper.Map<RoleViewDTO>(role);
        }

        public async Task<bool> UpdateRoleAsync(Guid id, RoleUpdateDTO roleDTO)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null) return false;
            _mapper.Map<Role>(roleDTO);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
