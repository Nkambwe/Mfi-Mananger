using MfiManager.Middleware.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/settings")]
    public class MfiConfigurationController(IServiceLoggerFactory loggerFactory) : MfiBaseController(loggerFactory) {

        [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Settings says 'Welcome to MFI-Middleware API'");
        }
    }
}
