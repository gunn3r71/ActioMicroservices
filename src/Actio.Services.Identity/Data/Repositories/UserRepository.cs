using System;
using System.Threading.Tasks;
using Actio.Services.Identity.Domain.Entities;
using Actio.Services.Identity.Domain.Repositories;
using MongoDB.Driver;

namespace Actio.Services.Identity.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _db;
        private IMongoCollection<User> _collection => _db.GetCollection<User>("Users");

        public async Task<User> GetAsync(Guid id) =>
            (await _collection.FindAsync(x => x.Id == id)).SingleOrDefault();

        public async Task<User> GetAsync(string email) =>
            (await _collection.FindAsync(x => x.Email == email.ToLowerInvariant())).FirstOrDefault();

        public async Task CreateAsync(User user) =>
            await _collection.InsertOneAsync(user);
    }
}