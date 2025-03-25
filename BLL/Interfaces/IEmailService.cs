namespace Common.Interfaces
{
    public interface IEmailService
    {
        Task SendActivationEmailAsync(string email, string activationLink);
    }
}
