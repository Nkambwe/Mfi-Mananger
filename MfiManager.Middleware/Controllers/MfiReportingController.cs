using MfiManager.Middleware.Configurations.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/reporting")]
    public class MfiReportingController(
        ILogger<MfiReportingController> logger,
        IEnvironmentProvider environment) 
        : MfiBaseController(logger, environment) {
        private readonly ILogger<MfiReportingController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult ReportingWelcome() {
            return Ok("Reporting says 'Welcome to MFI-Middleware API'");
        }
    }
}
