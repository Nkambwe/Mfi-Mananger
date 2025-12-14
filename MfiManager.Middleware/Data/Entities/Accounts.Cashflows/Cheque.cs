using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {
    public class Cheque : BaseEntity {
        public long BookId {get;set; }
        public string Number  {get;set; }
        public string IssuerAccount {get;set; }
        public string Recipient {get;set; }
        public string RecipientAccount {get;set; }
        public decimal Amount {get;set; }
        public string AmountInWords {get;set; }
        public ChequeStatus Status {get;set; }
        /// <summary>
        /// Get/Set whether payment made by this cheque wqs cancelled
        /// </summary>
        public bool Reversed {get;set; }
        public virtual ChequeBook Book { get; set; }

    }
}
