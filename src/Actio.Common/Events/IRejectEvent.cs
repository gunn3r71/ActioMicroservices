namespace Actio.Common.Events
{
    public interface IRejectEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}