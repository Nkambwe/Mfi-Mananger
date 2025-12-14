
using MfiManager.Middleware.Data.Entities.System;

namespace MfiManager.Middleware.Data.Services {
    public class CompanyService(ILogger<CompanyService> logger,
        IServiceLocalization localization) 
        : BaseService<CompanyService>(logger, localization), ICompanyService {

        public async Task<bool> SaveErrorAsync(SystemError errorObj) {
            return true;
        }

        public string DoSomething(string customerId) {

            using (Logger.BeginScope(new { Channel = "CUSTOMER-SERVICE", Id = customerId })) {
                Logger.LogInformation("Processing customer {CustomerId}", customerId);
                try {
                    return customerId;
                } catch (Exception ex) {
                    Logger.LogError(ex, "Error while processing customer {CustomerId}", customerId);
                    return null;
                }
            }
        }
    }
}
