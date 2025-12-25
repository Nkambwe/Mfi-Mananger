using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    public class LoanApproval : BaseEntity {
        public ApprovalStage ApprovalStage { get; set; }
        public DateTime ApprovalDate { get; set; }
        public decimal ApproveAmount { get; set; }
        public string Notes { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
        public long ApproverId { get; set; }
        public virtual LoanOfficer Approver { get; set; }
    }

}
