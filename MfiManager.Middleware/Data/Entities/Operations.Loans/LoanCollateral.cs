namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    public class IndividualLoanCollateral {
        public long CollateralId { get; set; }
        public long IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public virtual Collateral Collateral { get; set; }
    }

}
