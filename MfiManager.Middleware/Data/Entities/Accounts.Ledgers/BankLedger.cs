using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {

    public class BankLedger : BaseEntity {
        public string TransactionCode {get;set;}
        public DateTime PostedOn {get;set;}
        public string Folio {get;set;}
        public string Voucher {get;set;}
        public string Ledger {get;set;}
        public string Description {get;set;}
        public TransactionType TransactionType {get;set;}
        public TransactionNature TransactionNature {get;set;}
        /// <summary>
        /// Get/Set clearance status
        /// </summary>
        public PaymentStatus PaymentStatus {get;set;}
        public decimal Debit {get;set;}
        public decimal Credit {get;set;}
        public decimal Balance {get;set;}
        public bool Reconciled {get;set;}
        public string Currency {get;set;}
        public long? TransactionDocumentId  {get;set;}
        public long? BankAccountId {get;set;}
        public long? ChequeTransactionId {get;set;}
        public virtual BankAccount BankAccount { get; set; }
        public virtual TransactionDocument Document { get; set; }
        public virtual ChequeLedger ChequeTransaction {get;set;}
    }

}
