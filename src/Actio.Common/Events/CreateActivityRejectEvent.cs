namespace Actio.Common.Events
{
    public class CreateActivityRejectEvent : IRejectEvent
    {
        public CreateActivityRejectEvent()
        {
        }

        public CreateActivityRejectEvent(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }

        public string Reason { get; }
        public string Code { get; }
    }
}