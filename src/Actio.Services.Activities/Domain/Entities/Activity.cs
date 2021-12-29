using System;
using Actio.Common.Exceptions;

namespace Actio.Services.Activities.Domain.Entities
{
    public class Activity
    {
        protected Activity()
        {
        }

        public Activity(Guid id, 
            string name, 
            Category category, 
            string description,
            Guid userId,
            DateTime createdAt)
        {
            Id = id;
            Name = string.IsNullOrWhiteSpace(name) ? throw new ActioException("empty_activity_name") : name;
            Category = string.IsNullOrWhiteSpace(category.Name) ? throw new ActioException("empty_activity_category_name") : category.Name;
            Description = string.IsNullOrWhiteSpace(description) ? throw new ActioException("empty_activity_description") : description;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Category { get; }
        public string Description { get; }
        public Guid UserId { get; }
        public DateTime CreatedAt { get; }
    }
}