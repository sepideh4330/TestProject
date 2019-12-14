using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Project.Common.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request?.Headers != null && request.Headers[RequestedWithHeader] == XmlHttpRequest;
        }

        public static async Task<T> DeserializeJsonBodyAsAsync<T>(this HttpRequest request)
        {
            var json = await request.ReadBodyAsString().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<string> ReadBodyAsString(this HttpRequest request)
        {
            using (var bodyReader = new StreamReader(request.Body, Encoding.UTF8))
            {
                var body = await bodyReader.ReadToEndAsync().ConfigureAwait(false);
                request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
                return body;
            }
        }

        public static string GetToken(this HttpRequest httpRequestMessage)
        {
            var tokenRobotValue = httpRequestMessage.Headers.TryGetValue("Ionic-Token", out var tokenRobotValues);
            return tokenRobotValue ? tokenRobotValues.ToList()[0] : "";
        }
    }
}
