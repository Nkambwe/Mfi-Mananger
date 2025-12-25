using MfiManager.Middleware.Data.Entities.Accounts;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations {

    /// <summary>
    /// Class represents loan officers like Credit Officers, Credit Analysts, Senior Credit Analysts, Disbursement officers
    /// </summary>
    public class LoanOfficer : BaseEntity {
        /// <summary>
        /// Officer seriess like CO-001[Credit Office], CA-001[Credit Analyst], SC-001[Senior Credit Analyst], etc
        /// </summary>
        public string Series { get; set; }
        public OfficerPositionCode PositionCode { get; set; }
        public string PositionName { get; set; }
        public decimal MaximumApprovalAmount{get;set;}
        public bool Active { get; set; }
        public long UserId { get; set; }
        public virtual SystemUser SystemUser { get; set; } = null!;
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<LoanRecord> Loans { get; set; }
        public virtual ICollection<LoanApproval> LoanApprovals { get; set; } = [];
        public long? LedgerAccountId {get;set;}
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<LoanOfficerJournalType> JournalTypes { get; set; } = [];
        public virtual ICollection<LoanOfficerVoucherType> VoucherTypes {get;set;} = [];
    }

}
