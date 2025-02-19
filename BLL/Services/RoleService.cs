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

        public async Task<RoleDTO> CreateRoleAsync(RoleDTO roleDTO)
        {
            var role = _mapper.Map<Role>(roleDTO);
            role.Id = Guid.NewGuid();

            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return _mapper.Map<RoleDTO>(role);

        }

        public async Task<bool> DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null) return false;
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task<RoleDTO?> GetRoleByIdAsync(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<bool> UpdateRoleAsync(Guid id, RoleDTO roleDTO)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null) return false;
            _mapper.Map<Role>(roleDTO);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
