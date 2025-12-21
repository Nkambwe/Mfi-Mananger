using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Business group type item
    /// </summary>
    public class BusinessPostingItem: BaseEntity {
        /// <summary>
        /// Get / Set business group item code
        /// </summary>
        public string Code {get;set; }
        /// <summary>
        /// Get / Set business group item posting series number
        /// </summary>
        public string Series {get;set; }
        public string Description {get;set; }
        public string Notes {get;set; }
        /// <summary>
        /// Get / Set business group type Id
        /// </summary>
        public long BusinessPostingId {get;set;}
        public virtual BusinessPostingType BusinessPostingType { get; set; }
        public virtual ICollection<JournalType> Journals {get;set;} = [];
        public virtual ICollection<VoucherType> Vouchers {get;set;} = [];
    }
}
