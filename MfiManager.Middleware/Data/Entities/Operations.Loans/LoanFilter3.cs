namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanFilter3 : LoanFilterBase {
        public virtual ICollection<LoanRecord> Loans { get; set; }
        public override string ToString() => $"{Series}-{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
