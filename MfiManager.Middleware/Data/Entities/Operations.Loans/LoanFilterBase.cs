namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public abstract class LoanFilterBase : BaseEntity {
        public string Series { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
