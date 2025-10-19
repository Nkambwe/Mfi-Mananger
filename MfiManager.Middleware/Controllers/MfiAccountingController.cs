using MfiManager.Middleware.Configurations.Providers;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/accounting")]
    public class MfiAccountingController(
        ILogger<MfiAccountingController> logger, 
        IEnvironmentProvider environment)
        : MfiBaseController(logger, environment) {
        private readonly ILogger<MfiAccountingController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult AccountingWelcome() {
            return Ok("Accounting says 'Welcome to MFI-Middleware API'");
        }
    }
}
