using MfiManager.App.Models;

namespace MfiManager.App.Factories {
    public class MfiErrorFactory: IMfiErrorFactory {
        public Task<MfiErrorModel> PrepareErrorModelAsync(long companyId, string message, string source, string stacktrace)
            => Task.FromResult(new MfiErrorModel(){ 
                CompanyId = companyId,
                Message = message,
                Source = source,
                StackTrace = stacktrace
            });
    }
}
