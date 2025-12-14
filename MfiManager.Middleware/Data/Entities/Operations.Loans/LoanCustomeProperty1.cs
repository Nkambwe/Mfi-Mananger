namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanCustomeProperty1 : LoanCustomeProperty {
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];
        public override string ToString() => $"{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
