using System;

namespace Actio.Services.Activities.Domain.Models
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
            Name = name;
            Category = category.Name;
            Description = description;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}