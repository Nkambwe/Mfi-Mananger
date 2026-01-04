
using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Services {

    public class CustomerService(ILogger<CustomerService> logger, 
        IServiceLocalization localization) 
        : BaseService<CustomerService>(logger, localization), ICustomerService {
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

        public async Task<Individual> GetByIdAsync(long id) {
            return new Individual { 
                Id = id,
                FirstName = "Mark",
                MiddleName = "John",
                LastName = "Nkambwe"
            };
        }
    }
}
