using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {

    public class JournalType : BaseEntity {
        public string Code{ get; set; }
        public string JournalName{ get; set; }
        public string PostingSeries{ get; set; }
        public string LedgerNumber { get; set; }
        public JournalTransactionType PostingType{ get; set; }
        public bool AllowTaxDifference{ get; set; }
        public bool RequireVoucher{ get; set; }
        public bool MultiCurrency{ get; set; }
        public string Reference1{ get; set; }
        public string Reference2{ get; set; }
        public string Reference3{ get; set; }
        public string Reference4{ get; set; }
        public string Reference5{ get; set; }
        public string Reference6{ get; set; }
        /// <summary>
        /// Check whether it is system defined or user defined journal
        /// </summary>
        public bool System { get; set; }
        public bool Active { get; set; }
        /// <summary>
        /// Get/Set notes for creating this journal eg. Salaries, Reimbursement etc.
        /// </summary>
        public string Notes{ get; set; }
        public long? GeneralPostingId { get; set; }
        public long? BusinessPostingId{ get; set; }
        public long? ReasonId { get; set; }
        public virtual Reason Reason { get; set; }
        public virtual GeneralPostingItem GeneralPostingItem { get; set; }
        public virtual BusinessPostingItem BusinessPostingItem { get; set; }
        public virtual ICollection<CashierJournal> CashierJournals {get;set;} = [];
        public virtual ICollection<JournalTypeTaxGroup> JournalTraxGroup { get; set; } = [];
    }
}
