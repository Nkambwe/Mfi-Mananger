using Microsoft.AspNetCore.Mvc;

namespace MfiManager.Middleware.Controllers {
    [ApiController]
    [Route("mfi")]
    public class MfiController : ControllerBase {
        
        public MfiController() {
        }

        [HttpGet]
        public IActionResult Welcome() {
            return Ok("Welcome to MFI-Middleware API");
        }
    }
}
