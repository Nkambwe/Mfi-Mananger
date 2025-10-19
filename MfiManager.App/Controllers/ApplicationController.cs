using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Controllers {
    public class ApplicationController : Controller {
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger) {
            _logger = logger;
        }

        public IActionResult Login() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

    }
}
