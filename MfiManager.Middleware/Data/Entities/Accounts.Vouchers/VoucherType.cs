using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {
    public class VoucherType : BaseEntity {
        public string Code   { get; set; }
        public string PostingSeries  { get; set; }
        public string VoucherName   { get; set; }
        public string LedgerNumber  { get; set; }
        public PostingType Posting { get; set; }
        public long? GeneralPostingId  { get; set; }
        public long? BusinessPostingId  { get; set; }
        /// <summary>
        /// Check whether it is system defined or user defined voucher
        /// </summary>
        public bool System  { get; set; }
        public bool Active  { get; set; }
        /// <summary>
        /// Get/Set start number for this voucher
        /// </summary>
        public long StartNumber  { get; set; }
        /// <summary>
        /// Get/Set last used number for this voucher
        /// </summary>
        public long LastNumber { get; set; }
        /// <summary>
        /// Get/Set reason for creating this journal eg. Salaries, Reimbursement etc.
        /// </summary>
        public long? ReasonId  { get; set; }
        public virtual ReasonCategory Reason { get; set; }
        public virtual GeneralPosting GeneralPosting { get; set; }
        public virtual BusinessPosting BusinessPosting { get; set; }
        public virtual ICollection<Cashier> Cashiers {get;set;} = [];

    }
}
