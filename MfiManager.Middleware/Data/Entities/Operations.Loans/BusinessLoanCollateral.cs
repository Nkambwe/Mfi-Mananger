namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class BusinessLoanCollateral {
        public long CollateralId { get; set; }
        public long BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
        public virtual Collateral Collateral { get; set; }
    }

}
