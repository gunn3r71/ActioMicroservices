namespace Actio.Common.Events
{
    public class CreateUserRejectEvent : IRejectEvent
    {
        protected CreateUserRejectEvent()
        {
        }

        public CreateUserRejectEvent(string email, 
            string reason,
            string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }

        public string Email { get; }
        public string Reason { get; }
        public string Code { get; }
    }
}