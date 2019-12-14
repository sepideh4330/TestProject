using System.Threading.Tasks;

namespace Project.ServiceLayer.Contracts.Messages
{
    public interface ISmsService
    {
        Task SendSmsAsync(string number, string message,string userName,string password,string phoneNumber);
    }
}