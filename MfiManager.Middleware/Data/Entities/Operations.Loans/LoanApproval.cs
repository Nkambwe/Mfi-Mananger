using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    public class LoanApproval : BaseEntity {
        public ApprovalStage ApprovalStage { get; set; }
        public DateTime ApprovalDate { get; set; }
        public decimal ApproveAmount { get; set; }
        public string Notes { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
        public long ApproverId { get; set; }
        public virtual LoanOfficer Approver { get; set; }
    }

}
