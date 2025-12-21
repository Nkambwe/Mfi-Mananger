using MfiManager.Middleware.Enums;
using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;

namespace MfiManager.Middleware.Data.Entities.Accounts.Fees {

    public class InsuranceFeeLedger : BaseEntity {
          public long GeneralLedgerTransactionId {get;set; }
          public string TransactionCode {get;set; }
          public string Particulars {get;set; }
          public DateTime PostedOn {get;set; }
          public Payment Payment {get;set; }
          public string Cheque {get;set; }
          public decimal Amount {get;set; }
          public string Cashier {get;set; }
          public long FeeId {get;set; }
          public virtual ChargeableFee Fee { get; set; }
          public virtual Ledger GeneralLedgerTransaction { get; set; }
    }

}
