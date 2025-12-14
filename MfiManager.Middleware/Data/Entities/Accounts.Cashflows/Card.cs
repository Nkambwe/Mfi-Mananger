using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {

    public class Card : BaseEntity {
        public long VendorId { get; set; }
        public string Holder  { get; set; }
        public string CardNumber { get; set; }
        public CardType Type { get; set; }
        public CardTransactionType TransactionType  { get; set; }
        public bool Freeze { get; set; }
        public decimal Limit  { get; set; }
        public virtual Trader Vendor { get; set; }
        public virtual ICollection<CardLedger> Transactions {get;set;}=[];
    }
}
