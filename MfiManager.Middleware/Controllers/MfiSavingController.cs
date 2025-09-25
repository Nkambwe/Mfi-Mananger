using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {

    [ApiController]
    [Route("mfi/saving")]
    public class MfiSavingController: MfiBaseController  {
        [HttpGet("welcome")]
        public IActionResult SavingWelcome() {
            return Ok("Saving says 'Welcome to MFI-Middleware API'");
        }
    }
}
