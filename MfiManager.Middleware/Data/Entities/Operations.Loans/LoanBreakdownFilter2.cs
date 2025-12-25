namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanBreakdownFilter2 : LoanFilterBase {
        public virtual ICollection<GroupLoanBreakdown> LoanBreakDowns { get; set; } = [];
        public override string ToString() => $"{Series}-{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
