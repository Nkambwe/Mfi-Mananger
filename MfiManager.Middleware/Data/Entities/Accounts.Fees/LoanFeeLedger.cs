using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Fees {
    /// <summary>
    /// Loan fees transaction record for a given loan
    /// </summary>
    public class LoanFeeLedger : BaseEntity {
          public long GeneralLedgerTransactionId {get;set; }
          public string TransactionCode {get;set; }
          public DateTime PostedOn {get;set; }
          public string Particulars {get;set; }
          public Payment Payment {get;set; }
          public string Cheque {get;set; }
          public decimal Amount {get;set; }
          public string Cashier {get;set;}
          public long LoanId {get;set; }
          public long FeeId {get;set; }
          public long? LoanFeePaymentLevelId {get;set; } 
          public virtual ChargeableFee Fee { get; set; }
          public virtual LoanFeePaymentLevel LoanFeePaymentLevel { get; set; }
          public virtual Ledger GeneralLedgerTransaction { get; set; }
    }
}
