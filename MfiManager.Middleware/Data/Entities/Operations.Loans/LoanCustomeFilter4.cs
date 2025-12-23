namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanCustomeFilter4 : LoanFilterProperty {
        public string Account { get; set; }
        public string Label { get; set; }
        public string Activity { get; set; }
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];
        public override string ToString() => $"{Description.Trim()}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
