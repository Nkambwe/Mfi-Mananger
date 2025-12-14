using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class ChequeLedger : BaseEntity {
        public string TransactionId {get;set;}
        public string ChequeNumber {get;set;}
        public DateTime TransDate  {get;set;}
        public string Folio {get;set;}
        public string Particulars {get;set;}
        public ChequeStatus Status  {get;set;}
        public decimal Amount  {get;set;}
        public virtual ICollection<BankLedger> BankTransactions {get;set;}=[];
    }
}
