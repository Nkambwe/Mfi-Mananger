using MfiManager.Middleware.Data.Entities.Customers.Support;
using MfiManager.Middleware.Data.Entities.Operations;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {

    public class VoucherType : BaseEntity {
        public string Code   { get; set; }
        public string PostingSeries  { get; set; }
        public string VoucherName   { get; set; }
        public string LedgerNumber  { get; set; }
        public PostingType Posting { get; set; }
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

        public long? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public long? ReasonId  { get; set; }
         /// <summary>
        /// Get/Set reason for creating this journal eg. Salaries, Reimbursement etc.
        /// </summary>
        public virtual Reason Reason { get; set; }
        public long? GeneralPostingId  { get; set; }
        public virtual GeneralPostingItem GeneralPostingItem { get; set; }
        public long? BusinessPostingId  { get; set; }
        public virtual BusinessPostingItem BusinessPostingItem { get; set; }
        public virtual ICollection<CashierVoucher> CashierVouchers {get;set;} = [];
        public virtual ICollection<TellerVoucherType> TellerVouchers {get;set;} = [];
        public virtual ICollection<BranchVoucherType> BranchVouchers {get;set;} = [];
        public virtual ICollection<LoanOfficerVoucherType> LoanOfficerVouchers {get;set;} = [];
        
    }

}
