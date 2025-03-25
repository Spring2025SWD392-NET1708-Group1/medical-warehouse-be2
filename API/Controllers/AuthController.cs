using Common.DTOs;
using Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;


        public AuthController(IUserService userService, IConfiguration configuration, IAuthService authService, IEmailService emailService)
        {
            _userService = userService;
            _configuration = configuration;
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginDto)
        {
            try
            {
                var token = await _authService.CheckLogin(loginDto);
                if (token == null)
                    return Unauthorized();
                return Ok(token);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDTO userDto)
        {
            var existingUser = await _userService.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return BadRequest("User with this email already exists.");
            }

            var createdUser = await _userService.CreateUserAsync(userDto);
            var activationLink = "http://localhost:5090/api/auth/activate?token=" + createdUser.ActivationToken;
            await _emailService.SendActivationEmailAsync(userDto.Email, activationLink);
            return CreatedAtAction(nameof(Register), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("activate")]
        public async Task<IActionResult> ActivateAccount(Guid token)
        {
            try
            {
                await _authService.ActivateAccountAsync(token);
                return Ok("Account activated successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Policy = "Admin")]
        [HttpGet("test-admin")]
        public IActionResult TestAdmin()
        {
            return Ok("You have access to Admin resources!");
        }

        [Authorize(Policy = "Supplier")]
        [HttpGet("test-supplier")]
        public IActionResult TestSupplier()
        {
            return Ok("You have access to Supplier resources!");
        }

        [Authorize(Policy = "Staff")]
        [HttpGet("test-staff")]
        public IActionResult TestStaff()
        {
            return Ok("You have access to Staff resources!");
        }

        [Authorize(Policy = "Customer")]
        [HttpGet("test-customer")]
        public IActionResult TestCustomer()
        {
            return Ok("You have access to Customer resources!");
        }

        [Authorize(Policy = "DeliveryUnit")]
        [HttpGet("test-deliveryunit")]
        public IActionResult TestDeliveryUnit()
        {
            return Ok("You have access to Delivery Unit resources!");
        }
    }
}

