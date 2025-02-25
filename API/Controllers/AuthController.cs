
using BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BLL.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserCreateDTO loginDto)
        {
            var users = await _userService.GetAllUsersAsync();

            // Tìm người dùng khớp với email và password
            var user = users.FirstOrDefault(u =>
                u.Email == loginDto.Email && loginDto.Password == loginDto.Password);

            if (user == null) return Unauthorized(new { message = "Invalid email or password" });

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO userDto)
        {
            var createdUser = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(Register), new { id = createdUser.Id }, createdUser);
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("test-admin")]
        public IActionResult TestAdmin()
        {
            return Ok("You have access to Admin resources!");
        }

        [Authorize(Policy = "SupplierPolicy")]
        [HttpGet("test-supplier")]
        public IActionResult TestSupplier()
        {
            return Ok("You have access to Supplier resources!");
        }

        [Authorize(Policy = "StaffPolicy")]
        [HttpGet("test-staff")]
        public IActionResult TestStaff()
        {
            return Ok("You have access to Staff resources!");
        }

        [Authorize(Policy = "CustomerPolicy")]
        [HttpGet("test-customer")]
        public IActionResult TestCustomer()
        {
            return Ok("You have access to Customer resources!");
        }

        [Authorize(Policy = "DeliveryUnitPolicy")]
        [HttpGet("test-deliveryunit")]
        public IActionResult TestDeliveryUnit()
        {
            return Ok("You have access to Delivery Unit resources!");
        }

        private string GenerateJwtToken(UserViewDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
