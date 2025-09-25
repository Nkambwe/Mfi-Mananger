using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/shares")]
    public class MfiShareController: MfiBaseController  {
        [HttpGet("welcome")]
        public IActionResult ShareWelcome() {
            return Ok("Shares says 'Welcome to MFI-Middleware API'");
        }
    }
}
