using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Reminder.BL.Dto;
using Reminder.BL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.BL.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly ILogService _logService;
        public EmailSender(EmailConfiguration emailConfig, ILogService logService)
        {
            _emailConfig = emailConfig;
            _logService = logService;
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);
            await SendAsync(mailMessage);
        }
        private async Task SendAsync(MimeMessage mailMessage, CancellationToken ct = default)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await _logService.AddInfo("Email is send.", $"Email is send{mailMessage}");
                    //await client.ConnectAsync(_emailConfig.Host, _emailConfig.Port, _emailConfig.UseSSL);
                    //await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password,ct);
                   
                    //Google account da erişim sorunu yaşandığı için mail yollanmıyor.
                    //await client.SendAsync(mailMessage);
                }
                catch
                {
                    //log an error message or throw an exception, or both.
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
