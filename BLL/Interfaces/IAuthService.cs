using Common.DTOs;
namespace Common.Interfaces
{
    public interface IAuthService
    {
        Task<string> CheckLogin(UserLoginDTO loginDTO);
        Task ActivateAccountAsync(Guid activationToken);
    }
}

