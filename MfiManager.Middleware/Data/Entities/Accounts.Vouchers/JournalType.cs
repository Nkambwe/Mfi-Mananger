using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
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
        public long? GeneralPostingId { get; set; }
        public long? BusinessPostingId{ get; set; }
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
        public virtual ReasonCategory Reason { get; set; }
        public virtual ICollection<JournalTypeTaxGroup> TaxGroup { get; set; }
        public virtual GeneralPosting GeneralPosting { get; set; }
        public virtual BusinessPosting BusinessPosting { get; set; }
        public virtual ICollection<Cashier> Cashiers {get;set;}=[];
    }
}
