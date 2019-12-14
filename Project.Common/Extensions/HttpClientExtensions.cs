using System.Net.Http;

namespace Project.Common.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddRobotHeader(this HttpClient client)
        {
            client.DefaultRequestHeaders.Add("dornevis-robot", "dornevis-robot");
            client.DefaultRequestHeaders.Add("token-robot", "(7)t~Ja6rEAfL5#gzO+lpX1GmXgseMyqRf6DIzTjTs&SN~@P@VEr1jcwF$Hmz4bfdgN2_9YA*nR)cj%ziR2JHG@5DJ)Qs36lQm!3");
        }
    }
}
