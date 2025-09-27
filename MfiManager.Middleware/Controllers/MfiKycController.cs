using MfiManager.Middleware.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/kyc")]
    public class MfiKycController(IServiceLoggerFactory loggerFactory) : MfiBaseController(loggerFactory) {

        [HttpGet("welcome")]
        public IActionResult KycWelcome() {
            return Ok("Kyc says 'Welcome to MFI-Middleware API'");
        }
    }
}
