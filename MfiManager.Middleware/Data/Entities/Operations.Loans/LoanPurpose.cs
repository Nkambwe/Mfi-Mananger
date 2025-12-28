namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanPurpose : BaseEntity {
        public string Description { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<IndividualLoan> IndividualLoans {get;set; }=[];
        public virtual ICollection<GroupLoan> GroupLoans {get;set; }=[];
        public virtual ICollection<BusinessLoan> BusinessLoans {get;set; }=[];
    }
}
