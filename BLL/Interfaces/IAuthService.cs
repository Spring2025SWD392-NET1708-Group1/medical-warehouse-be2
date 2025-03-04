using BLL.DTOs;
namespace BLL.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(Guid userId, string roleName);
        Task<string> CheckLogin(UserLoginDTO loginDTO);
        Task ActivateAccountAsync(Guid activationToken);
        string HashPassword(string password);
    }
}

