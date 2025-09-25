using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/system")]
    public class MfiSystemController : MfiBaseController {
         [HttpGet("welcome")]
        public IActionResult SystemWelcome() {
            return Ok("Support says 'Welcome to MFI-Middleware API'");
        }
    }
}
