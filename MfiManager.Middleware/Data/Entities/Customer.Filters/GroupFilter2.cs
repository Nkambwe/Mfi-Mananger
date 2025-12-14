using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Filters {
    public class GroupFilter2 : ClientFilter {
        public virtual ICollection<Group> Groups {get;set;}

    }
}
