using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/system")]
    public class MfiSystemController(ILogger<MfiSystemController> logger) : MfiBaseController {
        private readonly ILogger<MfiSystemController> _logger = logger;
         [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Support says 'Welcome to MFI-Middleware API'");
        }
    }
}
