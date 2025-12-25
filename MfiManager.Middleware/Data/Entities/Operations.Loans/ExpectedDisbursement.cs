namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Track loan disbursement date from approval date
    /// </summary>
    public class ExpectedDisbursement : BaseEntity {
        public DateTime DisbursementDate { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
