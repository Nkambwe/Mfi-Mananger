using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Ledgers {
    public class ChequeLedger : BaseEntity {
        public string TransactionCode {get;set;}
        public string ChequeNumber {get;set;}
        public DateTime PostedOn  {get;set;}
        public string Folio {get;set;}
        public string Particulars {get;set;}
        public ChequeStatus ChequeStatus  {get;set;}
        public decimal Amount  {get;set;}
        public virtual ICollection<BankLedger> BankTransactions {get;set;}=[];
    }
}
