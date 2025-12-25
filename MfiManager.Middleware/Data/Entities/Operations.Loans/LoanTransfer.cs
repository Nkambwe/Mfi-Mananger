namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Transfer loan from credit officer to another credit officer
    /// </summary>
    public class LoanTransfer : BaseEntity {
        public string FormerOfficer { get; set; }
        public string CurrentOfficer { get; set; }
        public long LoanId { get; set; }
        public DateTime TranferDate { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
