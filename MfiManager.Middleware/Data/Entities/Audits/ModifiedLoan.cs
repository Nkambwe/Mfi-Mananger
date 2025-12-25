using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    /// <summary>
    /// Modified loan record
    /// </summary>
    public class ModifiedLoan: BaseEntity {
        public string LoanNumber { get; set; }
        public decimal InterestRate { get; set; }
        public int Installments { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? AssesementDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public ApprovalLevel ApprovalLevel { get; set; }
        public bool IsRescheduled { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public bool IsFrozeen { get; set; }
        public long ProductId { get; set; }
        public long BranchId { get; set; }
        public long CreditOfficerId { get; set; }
        public long? PersonId { get; set; }
        public long? BusinessId { get; set; }
        public long? MemberId { get; set; }
        public long? GroupId { get; set; }
        public long CycleId { get; set; }
        public long? FundId { get; set; }
        public long? PurposeId { get; set; }
        public long? Filter1Id { get; set; }
        public long? Filter2Id { get; set; }
        public long? Filter3Id { get; set; }
        public long? Filter4Id { get; set; }
        public long LoanId { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
