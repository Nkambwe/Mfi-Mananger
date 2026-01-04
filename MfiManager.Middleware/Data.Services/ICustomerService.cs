using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Services {
    public interface ICustomerService: IBaseService { 
        string DoSomething(string customerId);
        Task<Individual> GetByIdAsync(long id);
    }
}
