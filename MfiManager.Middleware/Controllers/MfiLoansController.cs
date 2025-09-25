using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/loans")]
    public class MfiLoansController: MfiBaseController  {
        [HttpGet("welcome")]
        public IActionResult LoansWelcome() {
            return Ok("Loans says 'Welcome to MFI-Middleware API'");
        }
    }
}
