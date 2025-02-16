using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users); // AutoMapper replaces manual mapping
        }

        public async Task<UserDTO?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<bool> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null) return false;

            _mapper.Map(userDTO, userEntity); // AutoMapper updates entity fields
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userEntity = await _context.Users.FindAsync(id);
            if (userEntity == null) return false;

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
