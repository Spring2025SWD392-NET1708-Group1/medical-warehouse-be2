using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class JwtUtils
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public JwtUtils(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public async Task<User?> GetUserFromToken()
        {
            // Access the ClaimsPrincipal (the User property contains the claims)
            var userClaims = _httpContextAccessor.HttpContext?.User;
            if (userClaims == null)
            {
                return null; // No user claims available
            }
            // Extract user ID from claims
            var userIdClaim = userClaims?.FindFirst(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(Guid.Parse(userIdClaim.Value));
            return user; // Returns the user ID or null if not found
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("role", user.Role.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("storageName", user.Storage?.Name ?? string.Empty),
                new Claim("storageId", user.StorageId.ToString() ?? string.Empty)

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
