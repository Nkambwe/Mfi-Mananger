using MfiManager.Middleware.Configurations.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/saving")]
    public class MfiSavingController(
        ILogger<MfiSavingController> logger,
        IEnvironmentProvider environment) 
        : MfiBaseController(logger, environment)  {
        private readonly ILogger<MfiSavingController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult SavingWelcome() {
            return Ok("Saving says 'Welcome to MFI-Middleware API'");
        }
    }
}
