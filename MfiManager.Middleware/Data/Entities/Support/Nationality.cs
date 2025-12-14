using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Country details
    /// </summary>
    public class Nationality : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Individual> Individuals { get; set; } = [];
        public virtual ICollection<Business> Businesses { get; set; } = [];
        public virtual ICollection<Group> Groups { get; set; } = [];
        public virtual ICollection<Member> Members { get; set; } = [];
        public virtual ICollection<Guarantor> Guarantors { get; set; } = [];

    }
}
