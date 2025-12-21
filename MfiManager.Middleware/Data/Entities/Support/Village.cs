using MfiManager.Middleware.Data.Entities.Archieves;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Support {
    public class Village : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public long  ParishId { get; set; }
        public virtual Parish Parish { get; set; }
        public virtual ICollection<Individual> Individuals { get; set; } = [];
        public virtual ICollection<Member> Members { get; set; } = [];
        public virtual ICollection<Guarantor> Guarantors { get; set; } = [];
        public virtual ICollection<Business> Businesses { get; set; } = [];
        public virtual ICollection<MemberArchive> MemberArchives { get; set; } = [];
        public virtual ICollection<IndividualArchive> IndividualArchives { get; set; } = [];
    }
}
