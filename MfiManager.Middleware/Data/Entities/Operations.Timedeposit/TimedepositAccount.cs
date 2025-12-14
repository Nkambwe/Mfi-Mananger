using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Timedeposit {
    /// <summary>
    /// Timedeposit account record
    /// </summary>
    public class TimedepositAccount : BaseEntity {
        public long ProductId {get;set; }
        public long BranchId {get;set; }
        public long? IndividualId {get;set; }
        public long? MemberId {get;set; }
        public long? GroupId {get;set; }
        public DateTime OpenedOn {get;set; }
        public string AccountNumber {get;set; }
        /// <summary>
        /// Get/Set timedeposit amount on account
        /// </summary>
        public decimal DepositAmount {get;set; }
        /// <summary>
        /// Get/Set client negotiated interest rate if different from product interest rate
        /// </summary>
        public decimal NegotiatedRate {get;set; }
        public decimal MaturityValue {get;set; }
        public DateTime MaturityDate {get;set; }
        public bool HoldInterest {get;set; }
        public bool Renewed {get;set; }
        public string RegisteredBy {get;set;}
        public virtual TimedepositProduct Product { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Individual IndividualClient { get; set; }
        public virtual Group GroupClient { get; set; }
        public virtual Member GroupMember { get; set; }
        public virtual ICollection<ModifiedTimedepositAccount> Modifications { get; set; } = [];
    }
}
