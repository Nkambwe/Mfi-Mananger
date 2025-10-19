using MfiManager.App.Models;

namespace MfiManager.App.Factories {

    public interface IViewErrorFactory {

        Task<ErrorViewModel> Prepare401ErrorViewModelAsync(bool isLive, HttpContext context);
        Task<ErrorViewModel> Prepare403ErrorViewModelAsync(bool isLive, HttpContext context);
        Task<ErrorViewModel> Prepare404ErrorViewModelAsync(bool isLive, HttpContext context);
        Task<ErrorViewModel> Prepare500ErrorViewModelAsync(bool isLive, HttpContext context);
        Task<ErrorViewModel> Prepare503ErrorViewModelAsync(bool isLive, HttpContext context);
    }
}
