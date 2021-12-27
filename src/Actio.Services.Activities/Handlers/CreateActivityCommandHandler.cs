using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
    {
        private readonly IBusClient _busClient;

        public CreateActivityCommandHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateActivityCommand command)
        {
            Console.WriteLine($"Creating activity: {command.Name}");

            await _busClient.PublishAsync(new ActivityCreatedEvent(command.Id,
                command.UserId,
                command.Category,
                command.Name,
                command.Description,
                command.CreatedAt)
            );
        }
    }
}