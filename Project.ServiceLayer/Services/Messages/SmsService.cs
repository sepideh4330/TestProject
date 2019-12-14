using System.Threading.Tasks;
using Project.Common.Helpers;
using Project.ServiceLayer.Contracts.Messages;

namespace Project.ServiceLayer.Services.Messages
{
    public class SmsService : ISmsService
    {
        public Task SendSmsAsync(string number, string message,string userName,string password,string phoneNumber)
        {
            var sendSms = SmsPanel.SendSms(number, message,userName,password,phoneNumber);
            return Task.FromResult(sendSms);
        }
    }
}
