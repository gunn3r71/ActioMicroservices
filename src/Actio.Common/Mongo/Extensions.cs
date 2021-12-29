﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public static class Extensions
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOptions>(configuration.GetSection("Mongo"));

            services.AddSingleton<MongoClient>(x =>
            {
                var opt = x.GetService<IOptions<MongoOptions>>();

                return new MongoClient(opt.Value.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(x =>
            {
                var opt = x.GetService<IOptions<MongoOptions>>();
                var client = x.GetService<MongoClient>();

                return client.GetDatabase(opt.Value.Database);
            });

            services.AddScoped<IDatabaseInitializer, MongoInitializer>();
            
            services.AddScoped<IDatabaseSeeder, MongoSeeder>();
        }
    }
}