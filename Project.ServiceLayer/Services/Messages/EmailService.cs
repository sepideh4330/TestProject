using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Project.ServiceLayer.Contracts.Messages;

namespace Project.ServiceLayer.Services.Messages
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sepidehkhodadadi86", "shambalile")
            };
            client.EnableSsl = true;
            var mailMessage = new MailMessage
            {
                From = new MailAddress("sepidehkhodadadi86@gmail.com")
            };
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            return client.SendMailAsync(mailMessage);
        }

        public Task SendEmailAsync<T>(string email, string subject, string viewNameOrPath, T model)
        {
            throw new NotImplementedException();
        }
    }
}
