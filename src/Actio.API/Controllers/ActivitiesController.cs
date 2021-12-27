using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ActivitiesController : BaseController
    {
        private readonly IBusClient _busClient;

        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityCommand command)
        {
            try
            {
                command.Id = Guid.NewGuid();
                command.CreatedAt = DateTime.UtcNow;

                await _busClient.PublishAsync(command);

                return Accepted($"activities/{command.Id}");
            }
            catch (Exception)
            {
                return Problem("Something went wrong with your request, please, try again.");
            }
        }
    }
}
