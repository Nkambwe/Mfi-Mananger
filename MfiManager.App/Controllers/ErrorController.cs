using MfiManager.App.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Controllers {
    public class ErrorController(IEnvironmentProvider environment) : Controller {
        protected readonly IEnvironmentProvider Environment = environment;

        public IActionResult Status404() {
            return View();
        }

        public IActionResult Status500() {
            return View();
        }
    }
}
