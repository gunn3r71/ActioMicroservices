using System;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.API.Handlers
{
    public class ActivityCreatedEventHandler : IEventHandler<ActivityCreatedEvent>
    {
        public async Task HandleAsync(ActivityCreatedEvent @event)
        {
            await Task.CompletedTask;

            Console.WriteLine($"Activity created {@event.Name}");
        }
    }
}