using BLL.DTOs;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }

        public bool VerifyPassword(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);

            return inputHash == storedHash;
        }

        public async Task<string> CheckLogin(UserLoginDTO loginDTO)
        {
            var user = await _userRepository.GetByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            bool isValid = VerifyPassword(loginDTO.Password, user.PasswordHash);
            if (user.Email == loginDTO.Email && isValid)
            {
                return GenerateJwtToken(user.Id, user.Role.Name);
            }
            return null;
        }

        public async Task ActivateAccountAsync(Guid token)
        {
            var user = await _userRepository.GetByActivationTokenAsync(token);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.EmailConfirmed = true;
            user.ActivationToken = null;
            user.ActivationTokenExpires = null;
            await _userRepository.UpdateAsync(user);
        }

        public string GenerateJwtToken(Guid userId, string roleName)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim("role", roleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
