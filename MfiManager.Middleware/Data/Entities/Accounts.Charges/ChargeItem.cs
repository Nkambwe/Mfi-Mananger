using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {

    public class ChargeItem : BaseEntity {
        public string Code {get;set; }
        public int ChargeOn {get;set; }
        public string Description {get;set; }
        public decimal FixedAmount {get;set; }
        public bool IsRated {get;set; }
        public decimal Percentage {get;set; }
        public string Ledger {get;set;}
        public long? ProductId {get;set; }
        public long ChargeId {get;set; }
        public long? TaxId {get;set; }
        public virtual Tax Tax { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<ChargeItemCharge> Charges { get; set; }
        public virtual ICollection<ChargeStage> ChargeStages {get;set;}=[];
        public virtual ICollection<ChargeLedger> ChargeTransactions {get;set;}=[];
        public virtual ICollection<RegistrationLedger> ChargeTransactionsTransactions {get;set;}=[];

    }

}
