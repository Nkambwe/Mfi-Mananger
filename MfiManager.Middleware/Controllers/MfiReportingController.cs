using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi/reporting")]
    public class MfiReportingController : MfiBaseController {
        [HttpGet("welcome")]
        public IActionResult ReportingWelcome() {
            return Ok("Reporting says 'Welcome to MFI-Middleware API'");
        }
    }
}
