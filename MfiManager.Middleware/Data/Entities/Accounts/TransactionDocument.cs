using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    /// <summary>
    /// Class holds details of document attached to a transaction like a receipt, invoice, etc.
    /// </summary>
    public class TransactionDocument : BaseEntity {
        public string DocumentNumber {get;set;}
        public string DocumentName {get;set;}
        public string TransactionId {get;set;}
        public string Comment  {get;set;}

        public virtual ICollection<Voucher> Vouchers {get;set;} = [];
        public virtual ICollection<BankLedger> BankLedgerEntries {get;set;} = [];

    }
}
