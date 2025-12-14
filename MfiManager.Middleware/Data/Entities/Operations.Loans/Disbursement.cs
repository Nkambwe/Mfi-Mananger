using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan disbursement record
    /// </summary>
    public class Disbursement : BaseEntity {
        public long LoanId { get; set; }
        public string Transaction { get; set; }
        public DateTime DisbursementOn { get; set; }
        public decimal DisbursedAmount { get; set; }
        public DisbursementType Type { get; set; }
        public string DisbursedBy { get; set; }
        public virtual LoanRecord Loan { get; set; }

    }
}
