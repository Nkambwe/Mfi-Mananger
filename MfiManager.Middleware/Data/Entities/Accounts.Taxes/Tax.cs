using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Operations.Trade;

namespace MfiManager.Middleware.Data.Entities.Accounts.Taxes {
    public class Tax : BaseEntity {
        public string Code {get;set; }
        public string Description {get;set; }
        /// <summary>
        /// Get or Set whether tax is charged as percentage rate
        /// </summary>
        public bool IsRated {get;set; }
        /// <summary>
        /// Get or Set percentage rate charge
        /// </summary>
        public virtual decimal Rate {get;set; }
        /// <summary>
        /// Get or set flat rate charged
        /// </summary>
        public virtual decimal FlatAmount {get;set; }   
        public bool Suspend {get;set; }
        public long TaxGroupId {get;set; }
        public string Notes {get;set; }
        public virtual TaxGroup TaxGroup { get; set; }
        public virtual ICollection<SupplierTax> Suppliers {get;set; }
        public virtual ICollection<TaxableItem> TaxableItems {get;set;}=[];
        public virtual ICollection<TraderTax> Vendors {get;set; } = [];
        public virtual ICollection<ChargeItem> ChargedItems {get;set;} = [];

    }
}
