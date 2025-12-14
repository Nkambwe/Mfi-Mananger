using MfiManager.App.Enums;
using MfiManager.App.Factories;
using MfiManager.App.Http.Responses;
using MfiManager.App.Infrastructure.Settings;
using MfiManager.App.Infrastructure.Utils;
using MfiManager.App.Models;
using MfiManager.App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MfiManager.App.Controllers {

    public class ApplicationController(ILogger<MfiAppBaseController> logger, 
            IEnvironmentProvider environment, 
            IWebHelper webHelper, 
            ILocalizationService localizationService, 
            IMfiErrorService errorService, 
            IMfiErrorFactory errorFactory,
            IInstallationFactory instllationFactory,
            IInstallService installService,
            SessionManager sessionManager) 
        : MfiAppBaseController(logger, 
                                environment, 
                                webHelper, 
                                localizationService, 
                                errorService, 
                                errorFactory, 
                                sessionManager) {
        private readonly IInstallationFactory _instllationFactory = instllationFactory;
        private readonly IInstallService _installService = installService;

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
        public async Task<IActionResult> Install(InstallationModel model) {

            try {
                if (!ModelState.IsValid) {
                    var errors = ModelState.Where(x => x.Value.Errors.Count > 0)
                                           .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors
                                           .Select(e => e.ErrorMessage).ToArray());
                   return Json(new { success = false, error = errors });
                }

                //..setup company
                var response = await _installService.RegisterCompanyAsync(model,WebHelper.GetCurrentIpAddress());
                Logger.LogError("SETUP RESPONSE: {Response}", JsonSerializer.Serialize(response));
                if (response.HasError) {
                    return Ok(new { status = false, message = response.Error?.Message });
                }
        
                //..success response
                var serviceResponse = response.Data;
                if (SuccessfulResponse(serviceResponse)) {
                    return Json(new { 
                        status = true, 
                        redirectUrl = Url.Action("Login", "Application"),
                        data = new {
                            status = true
                        }
                    });
                }

                string errorMessage = serviceResponse != null ? $"{serviceResponse.Message}" 
                    : LocalizationService.GetLocalizedLabel("App.Error.Unknown");
                var responseErrors = new { general = new[] { errorMessage } };
                return Json(new { status = serviceResponse.Status, error = responseErrors });
        
            } catch (Exception ex) { 
                Logger.LogError("Installation Error");
                Logger.LogError("Error Message - {Message}", ex.Message);
                Logger.LogError("{StackTrace}", ex.StackTrace);
                return Redirect(Url.Action("Status500", "Error"));   
            }
        }

        
        [HttpGet]
        public virtual IActionResult ChangeLanguage(string language) {
            LocalizationService.SaveCurrentLanguage(language);
            return RedirectToAction("Setup", "Application");
        }

        #region Private methods
        private static bool SuccessfulResponse(MfiHttpStatusResponse serviceResponse) 
            => serviceResponse != null &&  serviceResponse.Status;

        #endregion

    }
}
