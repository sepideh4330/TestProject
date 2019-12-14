namespace Project.Common.Utilities.ProtectionProvider
{
    public interface IProtectionProviderService
    {
        string Decrypt(string inputText);
        string Encrypt(string inputText);
    }
}
