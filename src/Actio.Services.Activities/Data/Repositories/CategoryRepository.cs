using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Entities;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver;

namespace Actio.Services.Activities.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _db;
        private IMongoCollection<Category> _collection => _db.GetCollection<Category>("Categories");

        public CategoryRepository(IMongoDatabase db)
        {
            _db = db;
        }

        public async Task<Category> GetAsync(string name) =>
            await _collection.Find(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant()).FirstOrDefaultAsync();
        
        public async Task<IEnumerable<Category>> BrowseAsync() =>
            await _collection.AsQueryable().ToListAsync();

        public async Task AddAsync(Category category) =>
            await _collection.InsertOneAsync(category);
    }
}