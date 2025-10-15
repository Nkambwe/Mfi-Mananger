using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Areas.BackOffice.Controllers {
    [Area("BackOffice")]
    public class ReportsController : Controller {
        public IActionResult Index() {
            return View();
        }

    }
}
