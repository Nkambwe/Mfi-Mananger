using MfiManager.App.Factories;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Models;
using MfiManager.App.Services;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Controllers {

    public class ApplicationController(ILogger<MfiAppBaseController> logger, 
            IEnvironmentProvider environment, 
            IWebHelper webHelper, 
            ILocalizationService localizationService, 
            IMfiErrorService errorService, 
            IMfiErrorFactory errorFactory,
            IInstallationFactory instllationFactory,
            SessionManager sessionManager) 
        : MfiAppBaseController(logger, 
                                environment, 
                                webHelper, 
                                localizationService, 
                                errorService, 
                                errorFactory, 
                                sessionManager) {
        private readonly IInstallationFactory _instllationFactory = instllationFactory;

        public IActionResult Login() {
            return View();
        }

        public IActionResult Logout() {
            return View();
        }

        public async Task<IActionResult> Setup() {
            try {
                Logger.LogInformation("Setting up application");
                var model = await _instllationFactory.PrepareInstallationModelAsync();
                model.ApplicationLanguage = LocalizationService.GetCurrentLanguage().Code;
                return View(model);
            } catch (Exception ex) {
                Logger.LogError("Installation Error");
                Logger.LogError("Error Message - {Message}", ex.Message);
                Logger.LogError("{StackTrace}", ex.StackTrace);
                 return Redirect(Url.Action("Status500", "Error"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Install(InstallationModel installation) {
            var msg = await Task.FromResult(installation);
            return Ok(new {data = msg});
        }

        
        [HttpGet]
        public virtual IActionResult ChangeLanguage(string language) {
            LocalizationService.SaveCurrentLanguage(language);
            return RedirectToAction("Setup", "Application");
        }

    }
}
