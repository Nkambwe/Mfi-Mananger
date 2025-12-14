using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Vouchers {
    public class Journal : Transaction {
        public JournalStatus Status {get;set;}
        public string ApprovedBy {get;set;}
        public virtual ICollection<Voucher> VoucherTransactions {get;set;}=[];

    }
}
