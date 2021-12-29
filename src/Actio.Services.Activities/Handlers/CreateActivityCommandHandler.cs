using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        private ILogger _logger;

        public CreateActivityCommandHandler(IBusClient busClient, 
            IActivityService activityService,
            ILogger logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivityCommand command)
        {
            _logger.LogInformation($"Creating activity: {command.Name}");
            try

            {
                await _activityService.AddAsync(command.Id,
                    command.UserId,
                    command.Category,
                    command.Name,
                    command.Description,
                    command.CreatedAt);

                var createdEvent = new ActivityCreatedEvent(command.Id,
                    command.UserId,
                    command.Category,
                    command.Name,
                    command.Description,
                    command.CreatedAt);

                await _busClient.PublishAsync(createdEvent);
            }
            catch (ActioException ex)
            {
                var rejectedEvent = new CreateActivityRejectEvent(ex.Message, ex.Code);
                await _busClient.PublishAsync(rejectedEvent);
            }
            catch (Exception ex)
            {
                var rejectedEvent = new CreateActivityRejectEvent(ex.Message, "error");
                await _busClient.PublishAsync(rejectedEvent);
            }
        }
    }
}