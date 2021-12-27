using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Actio.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IBusClient _busClient;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            try
            {
                await _busClient.PublishAsync(command);

                return Accepted();
            }
            catch (Exception)
            {
                return Problem("Something went wrong with your request, please, try again.");
            }
        }
    }
}