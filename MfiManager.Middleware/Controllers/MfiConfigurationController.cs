using MfiManager.Middleware.Configurations.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/settings")]
    public class MfiConfigurationController( ILogger<MfiConfigurationController> logger,
        IEnvironmentProvider environment) : MfiBaseController(logger, environment){
        private readonly ILogger<MfiConfigurationController> _logger = logger;

        [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Settings says 'Welcome to MFI-Middleware API'");
        }
    }
}
