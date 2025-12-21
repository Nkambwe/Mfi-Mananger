using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;

namespace MfiManager.Middleware.Data.Entities.Accounts {

    /// <summary>
    /// Class holds details of document attached to a transaction like a receipt, invoice, etc.
    /// </summary>
    public class TransactionDocument : BaseEntity {
        public string TransactionCode {get;set;}
        public string DocumentNumber {get;set;}
        public string DocumentName {get;set;}
        public string Notes  {get;set;}
        public long DocumentTypeId {get;set;}
        public virtual TransactionDocumentType DocumentType { get; set; }
        public virtual ICollection<Voucher> VoucherTransactions { get; set; } = [];
        public virtual ICollection<BankLedger> BankLedgerTransactions { get; set; } = [];
    }

}
