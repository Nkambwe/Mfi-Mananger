using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/shares")]
    public class MfiShareController(ILogger<MfiShareController> logger) : MfiBaseController  {
        private readonly ILogger<MfiShareController> _logger = logger;
        [HttpGet("welcome")]
        public IActionResult ShareWelcome() {
            return Ok("Shares says 'Welcome to MFI-Middleware API'");
        }
    }
}
