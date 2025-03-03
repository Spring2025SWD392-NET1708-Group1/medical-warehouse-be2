using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit.Text;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;

namespace BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public const string logoUrl = "https://img.freepik.com/premium-vector/online-education-logo-design-template_556845-290.jpg?semt=ais_hybrid";

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

        private string GenerateActivationEmailBody(string activationLink, string userName = "")
        {
            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            </head>
            <body style='margin: 0; padding: 0; font-family: Arial, sans-serif; line-height: 1.6; background-color: #f4f4f4;'>
                <div style='max-width: 600px; margin: 0 auto; padding: 20px;'>
                    <div style='background-color: #ffffff; padding: 40px; border-radius: 10px; box-shadow: 0 2px 4px rgba(0,0,0,0.1);'>
                        <div style='text-align: center; margin-bottom: 30px;'>
                            <!-- Logo của nền tảng học trực tuyến -->
                            <img src={logoUrl} alt='Course Platform Logo' style='max-width: 150px;'>
                        </div>
            
                        <h1 style='color: #333333; font-size: 24px; margin-bottom: 20px; text-align: center;'>Chào Mừng Bạn Đến Với Hệ Thống Học Trực Tuyến!</h1>
            
                        <p style='color: #666666; font-size: 16px; margin-bottom: 20px;'>
                            {(string.IsNullOrEmpty(userName) ? "Xin chào học viên mới" : $"Xin chào {userName},")}
                        </p>
            
                        <p style='color: #666666; font-size: 16px; margin-bottom: 20px;'>
                            Chúc mừng bạn đã đăng ký tham gia hành trình học tập cùng chúng tôi! Để bắt đầu trải nghiệm học tập trực tuyến với hàng nghìn khóa học chất lượng, vui lòng xác thực tài khoản của bạn bằng cách nhấn vào nút bên dưới:
                        </p>
            
                        <div style='text-align: center; margin-bottom: 30px;'>
                            <a href='{activationLink}' 
                               style='display: inline-block; padding: 15px 30px; background-color: #4CAF50; color: #ffffff; text-decoration: none; border-radius: 5px; font-size: 16px; font-weight: bold; text-transform: uppercase; transition: background-color 0.3s ease;'>
                                Kích Hoạt Tài Khoản
                            </a>
                        </div>
            
                        <p style='color: #666666; font-size: 16px; margin-bottom: 20px;'>
                            Sau khi xác thực, bạn sẽ có thể:
                        </p>
            
                        <ul style='color: #666666; font-size: 16px; margin-bottom: 30px; padding-left: 20px;'>
                              <li style='margin-bottom: 10px;'>✨ Kho khóa học đa dạng, chất lượng</li>
                            <li style='margin-bottom: 10px;'>🎓 Giảng viên giàu kinh nghiệm</li>
                            <li style='margin-bottom: 10px;'>💡 Nội dung học tập thực tiễn</li>
                            <li style='margin-bottom: 10px;'>🏆 Chứng chỉ có giá trị</li>
                        </ul>
            
                        <p style='color: #666666; font-size: 14px; margin-bottom: 20px;'>
                            Nếu bạn không thể nhấn vào nút trên, vui lòng copy và paste đường link sau vào trình duyệt:
                        </p>
            
                        <p style='color: #666666; font-size: 14px; margin-bottom: 30px; word-break: break-all;'>
                            {activationLink}
                        </p>
            
                        <div style='border-top: 1px solid #eeeeee; padding-top: 20px; margin-top: 20px;'>
                            <p style='color: #666666; font-size: 14px; margin-bottom: 20px;'>
                                Nếu bạn cần hỗ trợ hoặc có bất kỳ câu hỏi nào, đừng ngần ngại liên hệ với đội ngũ hỗ trợ của chúng tôi qua email: trilaptrinhngu@gmail.com
                            </p>
                
                            <p style='color: #666666; font-size: 14px; margin-bottom: 20px;'>
                                Chúc bạn có những trải nghiệm học tập tuyệt vời!
                            </p>
                        </div>

                        <div style='border-top: 1px solid #eeeeee; padding-top: 20px; margin-top: 20px; text-align: center;'>
                            <p style='color: #999999; font-size: 14px; margin-bottom: 10px;'>
                                Nếu bạn không thực hiện yêu cầu này, vui lòng bỏ qua email này.
                            </p>
                            <p style='color: #999999; font-size: 14px;'>
                                © 2024 CourseOnlineFSA. Đã đăng ký bản quyền.
                            </p>
                        </div>
                    </div>
                </div>
            </body>
            </html>";
        }
    }
}
