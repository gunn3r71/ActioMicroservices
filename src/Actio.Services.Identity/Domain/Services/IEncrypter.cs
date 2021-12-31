namespace Actio.Services.Identity.Domain.Services
{
    public interface IEncrypter
    {
        string Encrypt(string value);
    }
}