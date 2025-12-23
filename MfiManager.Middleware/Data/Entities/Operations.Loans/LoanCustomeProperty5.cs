namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanCustomeProperty5 : LoanFilterProperty {
        public virtual ICollection<LoanBreakdown> Targets { get; set; } = [];
        public override string ToString() => $"{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
