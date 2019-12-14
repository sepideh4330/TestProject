using System.Threading.Tasks;

namespace Project.ServiceLayer.Contracts.Messages
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync<T>(string email, string subject, string viewNameOrPath, T model);
    }
}
