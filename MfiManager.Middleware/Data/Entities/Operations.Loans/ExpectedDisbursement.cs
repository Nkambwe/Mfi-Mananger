namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Track loan disbursement date from approval date
    /// </summary>
    public class ExpectedDisbursement : BaseEntity {
        public DateTime DisbursementDate { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
