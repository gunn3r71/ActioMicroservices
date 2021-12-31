using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Entities;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Domain.Services;
using MongoDB.Driver.Core.WireProtocol.Messages.Encoders;

namespace Actio.Services.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository,
            IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email);

            if (user is not null)
                throw new ActioException("email_in_use", $"The {email} cannot be used");

            user = new User(email, name);
            user.SetPassword(password, _encrypter);

            await _userRepository.CreateAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user is null)
                throw new ActioException("invalid_credentials", $"Invalid credentials");

            if (!user.ValidatePassword(password, _encrypter))
                throw new ActioException("invalid_credentials", $"Invalid credentials");
        }
    }
}