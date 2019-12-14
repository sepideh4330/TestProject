using System;
using System.Security.Cryptography;
using System.Text;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class SecurityService : ISecurityService
    {
        private readonly RandomNumberGenerator _randomNumberGenerator = RandomNumberGenerator.Create();

        public string GetSha256Hash(string input)
        {
            using (var hashAlgorithm = new SHA256CryptoServiceProvider())
            {
                var byteValue = Encoding.UTF8.GetBytes(input);
                var byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }

        public Guid CreateCryptographicallySecureGuid()
        {
            var bytes = new byte[16];
            _randomNumberGenerator.GetBytes(bytes);
            return new Guid(bytes);
        }
    }
}
