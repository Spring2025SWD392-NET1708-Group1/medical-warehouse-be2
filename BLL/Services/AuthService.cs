using BLL.DTOs;
using BLL.Interfaces;
using BLL.Utils;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto;
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
        private readonly JwtUtils _jwtUtils;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, JwtUtils jwtUtils)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }
        public async Task<string> CheckLogin(UserLoginDTO loginDTO)
        {
            var user = await _userRepository.GetByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            bool isValid = PasswordUtils.VerifyPassword(loginDTO.Password, user.PasswordHash);
            if (user.Email == loginDTO.Email && isValid)
            {
                return _jwtUtils.GenerateJwtToken(user);
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


    }
}
