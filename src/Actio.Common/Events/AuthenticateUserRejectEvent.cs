namespace Actio.Common.Events
{
    public class AuthenticateUserRejectEvent : IRejectEvent
    {
        protected AuthenticateUserRejectEvent()
        {
        }

        public AuthenticateUserRejectEvent(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }

        public string Reason { get; }
        public string Code { get; }
    }
}