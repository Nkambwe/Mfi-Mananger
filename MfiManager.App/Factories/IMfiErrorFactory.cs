using MfiManager.App.Models;

namespace MfiManager.App.Factories {

    public interface IMfiErrorFactory {
        Task<MfiErrorModel> PrepareErrorModelAsync(long companyId, string message, string source, string stacktrace);
    }
}
