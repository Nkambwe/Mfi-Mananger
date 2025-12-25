namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public abstract class DueBase : BaseEntity {
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public decimal Commission { get; set; }
        public decimal Penalty { get; set; }
    }
}
