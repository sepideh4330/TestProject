using RestSharp;

namespace Project.Common.Helpers
{
    public static class SmsPanel
    {
        public static bool SendSms(string to, string message,string userName,string password,string phoneNumber)
        {
            var client = new RestClient("http://rest.payamak-panel.com/api/SendSMS/SendSMS");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("postman-token", "fcddb5f4-dc58-c7d5-4bf9-9748710f8789");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", $"username={userName}&password={password}&to={to}&from={phoneNumber}&text={message}&isflash=false", ParameterType.RequestBody);
            var response = client.Execute(request);
            return true;
        }
    }
}
