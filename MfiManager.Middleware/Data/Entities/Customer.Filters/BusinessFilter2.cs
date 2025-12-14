using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Filters {
    public class BusinessFilter2 : ClientFilter {
        public virtual ICollection<Business> Businesses {get;set;}

    }
}
