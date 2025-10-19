using MfiManager.App.Factories;
using MfiManager.App.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Controllers {

    public class ErrorController(IEnvironmentProvider environment, IViewErrorFactory errorFactory) : Controller {
        protected readonly IEnvironmentProvider _environment = environment;
        protected readonly IViewErrorFactory _errorFactory = errorFactory;
        
        public async Task<IActionResult> Status401() {
            var model = await _errorFactory.Prepare401ErrorViewModelAsync(_environment.IsLive, HttpContext);
            return View(model);
        }
        
        public async Task<IActionResult> Status403() {
            var model = await _errorFactory.Prepare403ErrorViewModelAsync(_environment.IsLive, HttpContext);
            return View(model);
        }
        
        public async Task<IActionResult> Status404() {
            var model = await _errorFactory.Prepare404ErrorViewModelAsync(_environment.IsLive, HttpContext);
            return View(model);
        }

        public async Task<IActionResult> Status500() {
            var model = await _errorFactory.Prepare500ErrorViewModelAsync(_environment.IsLive, HttpContext);
            return View(model);
        }

        public async Task<IActionResult> Status503() {
            var model = await _errorFactory.Prepare503ErrorViewModelAsync(_environment.IsLive, HttpContext);
            return View(model);
        }
    }
}
