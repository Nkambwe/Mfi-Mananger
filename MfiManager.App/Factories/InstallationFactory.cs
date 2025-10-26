using MfiManager.App.Models;

namespace MfiManager.App.Factories {
    public class InstallationFactory : IInstallationFactory {
        public async Task<InstallationModel> PrepareInstallationModelAsync() {
            return await Task.FromResult(new InstallationModel(){ 
                Company = new(),
                Owner = new(),
                DatabaseProvider = new()
            });
        }
    }
}
