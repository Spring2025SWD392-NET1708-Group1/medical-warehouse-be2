using BLL.DTOs;
namespace BLL.Interfaces
{
    public interface IAuthService
    {
        Task<string> CheckLogin(UserLoginDTO loginDTO);
        Task ActivateAccountAsync(Guid activationToken);
    }
}

