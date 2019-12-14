using System;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface ISecurityService
    {
        string GetSha256Hash(string input);

        Guid CreateCryptographicallySecureGuid();
    }
}
