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

        public async Task<IEnumerable<UserViewDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return _mapper.Map<IEnumerable<UserViewDTO>>(users);
        }

        public async Task<UserViewDTO?> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            return _mapper.Map<UserViewDTO>(user);
        }

        public async Task<UserViewDTO> CreateUserAsync(UserCreateDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.Id = Guid.NewGuid();

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserViewDTO>(userEntity);
        }

        public async Task<bool> UpdateUserAsync(Guid id, UserUpdateDTO userDTO)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            _mapper.Map(userDTO, user); // AutoMapper updates entity fields
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
