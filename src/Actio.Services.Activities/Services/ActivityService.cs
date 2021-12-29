using System;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Domain.Entities;
using Actio.Services.Activities.Domain.Repositories;
using MongoDB.Driver.Core.Authentication;

namespace Actio.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, 
            ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(category);

            if (activityCategory is null)
                throw new ActioException("category_not_found", $"Category: {name} does not exist");

            Activity activity = new (id,
                name,
                activityCategory,
                description,
                userId,
                createdAt);

            await _activityRepository.AddAsync(activity);
        }
    }
}