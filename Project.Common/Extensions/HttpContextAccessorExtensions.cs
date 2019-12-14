using System;
using Microsoft.AspNetCore.Http;

namespace Project.Common.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static Uri GetAbsoluteUri(this IHttpContextAccessor httpContextAccessor)
        {
            var request = httpContextAccessor.HttpContext.Request;
            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host,
                Path = request.Path.ToString(),
                Query = request.QueryString.ToString()
            };
            return uriBuilder.Uri;
        }
        public static Uri GetMyDomain(this IHttpContextAccessor httpContextAccessor)
        {
            var request = httpContextAccessor.HttpContext.Request;
            var uriBuilder = new UriBuilder
            {
                Scheme = request.Scheme,
                Host = request.Host.Host
            };
            return uriBuilder.Uri;
        }
    }
}