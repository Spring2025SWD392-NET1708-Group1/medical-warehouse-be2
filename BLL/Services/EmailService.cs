using BLL.DTOs;
using BLL.Interfaces;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace BLL.Services
{
  public class EmailService : IEmailService
  {
    private readonly EmailSettings _emailSettings;
    public const string logoUrl = "https://images-platform.99static.com//MDVqrTbdUmben2nTrA2mj8DHycw=/168x11:883x726/fit-in/500x500/99designs-contests-attachments/14/14940/attachment_14940716";

    public EmailService(IConfiguration configuration)
    {
      _emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
    }

    public Task SendActivationEmailAsync(string email, string activationLink)
    {
      Task.Run(async () =>
      {
        var message = CreateMimeMessage(email, "Account Activation", GenerateActivationEmailBody(activationLink));
        using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
        try
        {
          await ConnectAndSendEmailAsync(smtpClient, message);
        }
        catch (Exception ex)
        {
        }
      });

      return Task.CompletedTask;
    }

    private async Task ConnectAndSendEmailAsync(MailKit.Net.Smtp.SmtpClient smtpClient, MimeMessage message)
    {
      await smtpClient.ConnectAsync(_emailSettings.SmtpHost, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
      await smtpClient.AuthenticateAsync(_emailSettings.Sender, _emailSettings.Password);
      await smtpClient.SendAsync(message);
      await smtpClient.DisconnectAsync(true);
    }

    private MimeMessage CreateMimeMessage(string recipientEmail, string subject, string body)
    {
      var message = new MimeMessage();
      message.From.Add(new MailboxAddress("MWS", _emailSettings.Sender));
      message.To.Add(new MailboxAddress("", recipientEmail));
      message.Subject = subject;
      message.Body = new TextPart(TextFormat.Html) { Text = body };
      return message;
    }
    private string GenerateActivationEmailBody(string activationLink, string userName = "", string logoUrl = "")
    {
      return $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Welcome to Medical Warehouse System</title>
        </head>
        <body style='margin: 0; padding: 0; font-family: Arial, sans-serif; line-height: 1.6; background-color: #f4f4f4;'>
            <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                <div style='background-color: #ffffff; padding: 40px; border-radius: 10px; box-shadow: 0 2px 4px rgba(0,0,0,0.1);'>
                    <div style='text-align: center; margin-bottom: 30px;'>
                        <img src='{logoUrl}' alt='Medical Warehouse System Logo' style='max-width: 150px;'>
                    </div>
                    <h1 style='color: #333333; font-size: 24px; margin-bottom: 20px; text-align: center;'>
                        Welcome to the Medical Warehouse System!
                    </h1>

                    <p style='color: #666666; font-size: 16px; margin-bottom: 20px; text-align: center;'>
                        {(string.IsNullOrEmpty(userName) ? "We are excited to have you on board!" : $"Hello {userName},")}
                    </p>

                    <p style='color: #666666; font-size: 16px; margin-bottom: 20px; text-align: center;'>
                        Your account has been successfully created. To get started, please activate your account by clicking the button below.
                    </p>

                    <div style='text-align: center; margin-bottom: 30px;'>
                        <a href='{activationLink}' 
                           style='display: inline-block; padding: 15px 30px; background-color: #007BFF; color: #ffffff; text-decoration: none; border-radius: 5px; font-size: 16px; font-weight: bold; text-transform: uppercase; transition: background-color 0.3s ease;'>
                            Activate Your Account
                        </a>
                    </div>

                    <p style='color: #666666; font-size: 14px; margin-bottom: 20px; text-align: center;'>
                        If the button above does not work, copy and paste the following link into your browser:
                    </p>

                    <p style='color: #666666; font-size: 14px; margin-bottom: 30px; word-break: break-word; text-align: center;'>
                        <a href='{activationLink}' style='color: #007BFF; word-wrap: break-word;'>{activationLink}</a>
                    </p>

                    <div style='border-top: 1px solid #eeeeee; padding-top: 20px; margin-top: 20px; text-align: center;'>
                        <p style='color: #666666; font-size: 14px; margin-bottom: 10px;'>
                            Need help? Contact our support team at:
                        </p>
                        <p style='color: #007BFF; font-size: 14px; margin-bottom: 20px;'>
                            <a href='mailto:support@medicalwarehouse.com' style='color: #007BFF; text-decoration: none;'>
                                support@medicalwarehouse.com
                            </a>
                        </p>
                        <p style='color: #666666; font-size: 12px;'>
                            This is an automated email—please do not reply.
                        </p>
                    </div>

                </div>
            </div>
        </body>
        </html>";
    }
  }
}
