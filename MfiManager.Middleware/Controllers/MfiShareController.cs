using MfiManager.Middleware.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/shares")]
    public class MfiShareController(IServiceLoggerFactory loggerFactory) : MfiBaseController(loggerFactory)  {
        [HttpGet("welcome")]
        public IActionResult ShareWelcome() {
            return Ok("Shares says 'Welcome to MFI-Middleware API'");
        }
    }
}
