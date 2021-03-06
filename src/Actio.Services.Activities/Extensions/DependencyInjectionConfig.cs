using Actio.Common.Commands;
using Actio.Common.Mongo;
using Actio.Common.RabbitMq;
using Actio.Services.Activities.Data.Repositories;
using Actio.Services.Activities.Domain.Repositories;
using Actio.Services.Activities.Handlers;
using Actio.Services.Activities.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Actio.Services.Activities.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRabbitMq(configuration);
            services.AddMongoDb(configuration);
            services.AddScoped<ICommandHandler<CreateActivityCommand>, CreateActivityCommandHandler>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IActivityRepository, ActivityRepository>();

            services.AddScoped<IActivityService, ActivityService>();

            services.AddScoped<IDatabaseSeeder, CustomMongoSeeder>();

            return services;
        }
    }
}