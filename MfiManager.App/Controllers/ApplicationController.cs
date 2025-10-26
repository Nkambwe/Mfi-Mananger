using MfiManager.App.Factories;
using MfiManager.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Controllers {

    public class ApplicationController(ILogger<ApplicationController> logger,
        IInstallationFactory instllationFactory) : Controller {
        private readonly ILogger<ApplicationController> _logger = logger;
        private readonly IInstallationFactory _instllationFactory = instllationFactory;

        public IActionResult Login() {
            return View();
        }

        public IActionResult Logout() {
            return View();
        }

        public async Task<IActionResult> Setup() {
            try {
                _logger.LogInformation("Setting up application");
                return View(await _instllationFactory.PrepareInstallationModelAsync());
            } catch (Exception ex) {
                _logger.LogError("Installation Error");
                _logger.LogError("Error Message - {Message}", ex.Message);
                _logger.LogError("{StackTrace}", ex.StackTrace);
                 return Redirect(Url.Action("Status500", "Error"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Install([FromBody] InstallationModel installation) {
            return View();
        }

    }
}
