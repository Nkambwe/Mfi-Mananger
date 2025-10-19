using MfiManager.Middleware.Configurations.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/files")]
    public class MfiFileController(ILogger<MfiFileController> logger,
        IEnvironmentProvider environment) : MfiBaseController(logger, environment) {
        private readonly ILogger<MfiFileController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult FilesWelcome() {
            return Ok("Files says 'Welcome to MFI-Middleware API'");
        }
    }
}
