namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class Purpose : BaseEntity {
        public string Description { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<LoanRecord> Loans { get; set; } = [];
    }
}
