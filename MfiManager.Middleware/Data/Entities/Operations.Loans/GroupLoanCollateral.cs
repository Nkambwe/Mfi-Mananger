namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class GroupLoanCollateral {
        public long CollateralId { get; set; }
        public long GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public virtual Collateral Collateral { get; set; }
    }

}
