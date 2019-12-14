using System;
using System.Linq;
using DNTPersianUtils.Core;
using DNTPersianUtils.Core.Normalizer;
using Microsoft.AspNetCore.Identity;
using Project.Common.Extensions;

namespace Project.ServiceLayer.Services.Helper
{
    public class CustomNormalizer : UpperInvariantLookupNormalizer
    {
        public override string Normalize(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            key = key.Trim();

            if (key.IsEmailAddress())
            {
                key = FixGmailDots(key);
            }
            else
            {
                key = key.ApplyCorrectYeKe()
                    .RemoveDiacritics()
                    .CleanUnderLines()
                    .RemovePunctuation();
                key = key.Trim().Replace(" ", "");
            }

            key = key.ToUpperInvariant();
            return key;
        }

        private static string FixGmailDots(string email)
        {
            email = email.ToLowerInvariant().Trim();
            var emailParts = email.Split('@');
            var name = emailParts[0].Replace(".", string.Empty);

            var plusIndex = name.IndexOf("+", StringComparison.OrdinalIgnoreCase);
            if (plusIndex != -1)
            {
                name = name.Substring(0, plusIndex);
            }

            var emailDomain = emailParts[1];

            string[] domainsAllowedDots =
            {
                "gmail.com",
                "facebook.com"
            };

            var isFromDomainsAllowedDots = domainsAllowedDots.Any(domain => emailDomain.Equals(domain));
            return !isFromDomainsAllowedDots ? email : $"{name}@{emailDomain}";
        }
    }

}
