using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Savings account record
    /// </summary>
    public class SavingAccount : BaseEntity {
        public long? IndividualId { get; set; }
        public long? MemberId { get; set; }
        public long? GroupId { get; set; }
        public long? BusinessId { get; set; }
        public long ProductId { get; set; }
        public string AccountNumber { get; set; }
        public DateTime Opened { get; set; }
        public SavingAccountType Type { get; set; }
        public int Signatures { get; set; }
        public bool Dormant { get; set; }
        public bool Frozen { get; set; }
        public DateTime? ClosedOn { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual SavingProduct Product { get; set; }
        public virtual Individual IndividualClient { get; set; }
        public virtual Member GroupMember { get; set; }
        public virtual Group GroupClient { get; set; }
        public virtual Business BusinessClient { get; set; }
        /// <summary>
        /// Get/Set co-holders for joint account holders
        /// </summary>
        public virtual ICollection<SavingPartner> SavingPartners { get; set; } = [];
        public virtual ICollection<FrozenAccount> Freezes { get; set; } = [];
        public virtual ICollection<SavingAccountSignatory> Signatories { get; set; } = [];
        public virtual ICollection<SavingLedger> SavingTransactions { get; set; } = [];
        public virtual ICollection<SavingAccountInterest> Interests { get; set; } = [];
        public virtual ICollection<StandingOrder> StandingOrders { get; set; } = [];
        public virtual ICollection<OverdraftLoan> Overdrafts { get; set; } = [];
        public virtual ICollection<GroupRepaymentBreakdown> GroupRepaymentTransactions { get; set; } = [];
        public virtual ICollection<RepaymentLedger> RepaymentTransactions { get; set; } = [];
    }
}
