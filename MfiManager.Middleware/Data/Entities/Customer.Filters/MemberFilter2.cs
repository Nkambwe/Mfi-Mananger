using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Filters {
    public class MemberFilter2 : ClientFilter {
        public virtual ICollection<Member> Members {get;set;}

    }
}
