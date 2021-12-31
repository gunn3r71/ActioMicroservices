using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Actio.Services.Identity.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _service;
        private readonly IBusClient _busClient;

        public CreateUserCommandHandler(IBusClient busClient, 
            IUserService service)
        {
            _busClient = busClient;
            _service = service;
        }

        public async Task HandleAsync(CreateUserCommand command)
        {
            Console.WriteLine($"Creating user: {command.Email}");

            try
            {
                await _service.RegisterAsync(command.Email, command.Password, command.Name);

                await _busClient.PublishAsync(new UserCreatedEvent(command.Email, command.Name));
            }
            catch (ActioException ex)
            {
                var rejectedEvent = new CreateUserRejectEvent(command.Email, ex.Message, ex.Code);
                await _busClient.PublishAsync(rejectedEvent);
            }
            catch (Exception)
            {
                var rejectedEvent = new CreateUserRejectEvent(command.Email, string.Empty, "error");
                await _busClient.PublishAsync(rejectedEvent);
            }
        }
    }
}