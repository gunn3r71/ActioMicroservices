namespace Actio.Common.Events
{
    public class UserCreatedEvent : IEvent
    {
        protected UserCreatedEvent()
        {
        }

        public UserCreatedEvent(string email, string name)
        {
            Email = email;
            Name = name;
        }

        public string Email { get; }
        public string Name { get; }
    }
}