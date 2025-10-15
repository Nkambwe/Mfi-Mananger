using MfiManager.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
