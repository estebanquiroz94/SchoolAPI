namespace SchoolAPI.Interfaces.Services
{
    public interface IEncryptDecryptService
    {
        string Encrypt(string pass);
        string Decrypt(string pass);
    }
}
