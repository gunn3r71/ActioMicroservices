using EscNet.Cryptography.Interfaces;

namespace Actio.Services.Identity.Domain.Services
{
    public class Encrypter : IEncrypter
    {
        private readonly IRijndaelCryptography _cryptography;

        public Encrypter(IRijndaelCryptography cryptography)
        {
            _cryptography = cryptography;
        }

        public string Encrypt(string password) =>
            _cryptography.Encrypt(password);
    }
}