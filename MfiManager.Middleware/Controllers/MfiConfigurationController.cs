using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/settings")]
    public class MfiConfigurationController: MfiBaseController {

        [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Settings says 'Welcome to MFI-Middleware API'");
        }
    }
}
