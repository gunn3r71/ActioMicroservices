using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Entities;

namespace Actio.Services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);
    }
}