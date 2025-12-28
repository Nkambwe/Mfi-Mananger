namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Transfer loan from credit officer to another credit officer
    /// </summary>
    public class LoanTransfer : BaseEntity {
        public string FormerOfficer { get; set; }
        public string CurrentOfficer { get; set; }
        public DateTime TranferDate { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
