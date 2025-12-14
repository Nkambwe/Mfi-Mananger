namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanCustomeProperty5 : LoanCustomeProperty {
        public virtual ICollection<LoanBreakdown> Targets { get; set; } = [];
        public override string ToString() => $"{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
