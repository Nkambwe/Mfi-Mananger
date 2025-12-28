namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
   
    public class LoanFilter1 : LoanFilterBase {
        public virtual ICollection<IndividualLoan> IndividualLoans {get;set; }=[];
        public virtual ICollection<GroupLoan> GroupLoans {get;set; }=[];
        public virtual ICollection<BusinessLoan> BusinessLoans {get;set; }=[];
        public override string ToString() => $"{Series}-{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }

}
