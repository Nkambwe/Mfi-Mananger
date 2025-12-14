using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Customer.Filters {
    public class ClientFilter1 : ClientFilter {
        public virtual ICollection<Individual> People {get;set; }
        public virtual ICollection<Member> Members {get;set; }
        public virtual ICollection<Group> Groups {get;set; }
        public virtual ICollection<Business> Businesses {get;set; } 

    }
}
