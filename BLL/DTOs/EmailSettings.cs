﻿namespace BLL.DTOs
{
    public class EmailSettings
    {
        public string Sender { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string Password { get; set; }
        public string ResetTokenDuration { get; set; }
    }
}
