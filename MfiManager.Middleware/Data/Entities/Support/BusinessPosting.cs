using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Transactions posted based on nature of business such as Sale of services, Sale of products, Payment, Reimbursement, Returns
    /// </summary>
    public class BusinessPosting : BaseEntity {
        /// <summary>
        /// Get Or Set reason type
        /// </summary>
        public string Code {get;set;}

        /// <summary>
        /// Get Or Set reason type
        /// </summary>
        public string SeriesIdentifier {get;set;}
        public string CustomSeries {get;set;}
        public string Description {get;set;}
        public string Notes {get;set;}
        public virtual ICollection<BusinessPostingItem> BusinessItems {get;set;} = [];
        public virtual ICollection<JournalType> Journals {get;set;} = [];
        public virtual ICollection<VoucherType> Vouchers {get;set;} = [];
    }
}
