using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {

    public class RecurringItem : BaseEntity {
        public string Code {get;set;}
        public string Name {get;set;}
        public DateTime Starts {get;set;}
        public DateTime? Ends {get;set;}
        public decimal Amount  {get;set;}
        /// <summary>
        /// Get/Set monthly date the transaction should be posted eg. every 1st
        /// </summary>
        public int Every {get;set;}
        public PostingType PostingType {get;set;}
        /// <summary>
        /// Get Or Set whether transaction is posted automatically
        /// </summary>
        public bool Auto  {get;set;}
        public string PostingLedger {get;set;}
        /// <summary>
        /// Get or Set ledger account to post against
        /// </summary>
        public string AgainstLedger  {get;set;}
        public long? BranchId {get;set;}

        public virtual Branch Branch { get; set; }

    }
}
