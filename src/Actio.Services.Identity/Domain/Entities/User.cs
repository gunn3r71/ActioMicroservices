using System;
using Actio.Common.Exceptions;

namespace Actio.Services.Identity.Domain.Entities
{
    public class User
    {
        protected User()
        {
        }

        public User(string email, string name, string password)
        {
            Id = Guid.NewGuid();
            Email = string.IsNullOrWhiteSpace(email.ToLowerInvariant()) ? throw new ActioException("empty_user_email") : email;
            Name = string.IsNullOrWhiteSpace(name) ? throw new ActioException("empty_user_name") : name;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}