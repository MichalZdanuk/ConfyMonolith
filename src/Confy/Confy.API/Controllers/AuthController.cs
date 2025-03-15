using Microsoft.AspNetCore.Mvc;

namespace Confy.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Ok auth test");
        }
    }
}
