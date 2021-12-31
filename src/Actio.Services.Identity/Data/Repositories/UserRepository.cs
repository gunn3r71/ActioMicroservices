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
        
        public UserRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task<User> GetAsync(Guid id) =>
            (await Collection.FindAsync(x => x.Id == id)).SingleOrDefault();

        public async Task<User> GetAsync(string email) =>
            (await Collection.FindAsync(x => x.Email == email.ToLowerInvariant())).FirstOrDefault();

        public async Task CreateAsync(User user) =>
            await Collection.InsertOneAsync(user);

        private IMongoCollection<User> Collection => _db.GetCollection<User>("Users");
    }
}