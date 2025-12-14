namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Transfer loan from credit officer to another credit officer
    /// </summary>
    public class LoanTransfer : BaseEntity {
        public DateTime TranferedOn { get; set; }
        public string OldOfficer { get; set; }
        public string NewOfficer { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
