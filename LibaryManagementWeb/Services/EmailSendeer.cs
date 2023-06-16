using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LibaryManagementWeb.Services
{
    public class EmailSendeer : IEmailSender
    {
        private readonly string smtpServer;
        private readonly int smtpPort;
        private readonly string fromEmailAddress;

        public EmailSendeer(string smtpServer, int smtpPort, string fromEmailAddress)
        {
            this.smtpServer = smtpServer;
            this.smtpPort = smtpPort;
            this.fromEmailAddress = fromEmailAddress;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(fromEmailAddress),
                Body = htmlMessage,
                IsBodyHtml = true,
            };

            message.To.Add(new MailAddress(email));
            using var client = new SmtpClient(smtpServer, smtpPort);
            client.Send(message);
            return Task.CompletedTask;
        }
    }
}
