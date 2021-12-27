using System.Threading.Tasks;
using Actio.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Actio.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
            => Ok(new ResponseModel
            {
                Message = "Hello from Actio",
                Status = true,
                Data = null
            });
    }
}
