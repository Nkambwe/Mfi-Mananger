namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan application and approved amounts for a given loan
    /// </summary>
    public class ApprovedAmount : BaseEntity {
        public decimal AppliedForAmount { get; set; }
        public decimal AmountApproved { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
