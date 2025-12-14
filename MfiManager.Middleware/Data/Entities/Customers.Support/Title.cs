using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {

    public class Title : BaseEntity {
        public string Name { get; set; }
        public virtual ICollection<Individual> Individuals { get; set; } = [];
        public virtual ICollection<Member> Members { get; set; } = [];
        public virtual ICollection<Guarantor> Guarantors { get; set; } = [];

    }
}
