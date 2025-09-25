using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/kyc")]
    public class MfiKycController: MfiBaseController  {

        [HttpGet("welcome")]
        public IActionResult KycWelcome() {
            return Ok("Kyc says 'Welcome to MFI-Middleware API'");
        }
    }
}
