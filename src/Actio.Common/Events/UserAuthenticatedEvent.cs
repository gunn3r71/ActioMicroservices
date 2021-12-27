namespace Actio.Common.Events
{
    public class UserAuthenticatedEvent : IEvent
    {
        protected UserAuthenticatedEvent()
        {
        }

        public UserAuthenticatedEvent(string email)
        {
            Email = email;
        }

        public string Email { get; }
    }
}