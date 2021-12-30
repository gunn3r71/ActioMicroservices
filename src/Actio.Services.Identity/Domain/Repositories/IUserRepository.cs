using System;
using System.Threading.Tasks;
using Actio.Services.Identity.Domain.Entities;

namespace Actio.Services.Identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task CreateAsync(User user);
    }
}