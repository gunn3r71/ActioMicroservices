using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;

namespace Actio.Services.Identity.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IBusClient _busClient;

        public CreateUserCommandHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            await _busClient.PublishAsync(new UserCreatedEvent(command.Email, command.Name));
        }
    }
}