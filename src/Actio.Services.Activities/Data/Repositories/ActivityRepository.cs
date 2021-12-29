using System;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Models;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver;

namespace Actio.Services.Activities.Data.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _db;
        private IMongoCollection<Activity> _collection => _db.GetCollection<Activity>("Activities");

        public ActivityRepository(IMongoDatabase db)
        {
            _db = db;
        }
        
        public async Task<Activity> GetAsync(Guid id) =>
            await (_collection.Find(x => x.Id == id)).FirstOrDefaultAsync();

        public async Task AddAsync(Activity activity) =>
            await _collection.InsertOneAsync(activity);
    }
}