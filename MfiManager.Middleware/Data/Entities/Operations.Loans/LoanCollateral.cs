namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanCollateral {
        public long CollateralId { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public virtual Collateral Collateral { get; set; }
    }
}
