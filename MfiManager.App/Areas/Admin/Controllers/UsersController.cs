using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Areas.Admin.Controllers {

    [Area("Admin")]
    public class UsersController : Controller {
        public IActionResult Index() {
            return View();
        }

    }
}
