using MfiManager.App.Models;

namespace MfiManager.App.Factories {
    public interface IInstallationFactory {
        Task<InstallationModel> PrepareInstallationModelAsync();
    }
}
