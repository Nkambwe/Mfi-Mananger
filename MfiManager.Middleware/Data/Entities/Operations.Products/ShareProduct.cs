using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.Operations.Shares;
using MfiManager.Middleware.Data.Entities.System.Configurations;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    /// <summary>
    /// Share product
    /// </summary>
    public class ShareProduct : ProductBase {
        public long ProductTypeId { get; set; }
        public long? ChargeGroupId { get; set; } 
        public virtual ProductType ProductType { get; set; }
        public virtual ChargeGroup ChargeGroup { get; set; }
        public virtual ICollection<ChargeStage>  ChargeStages {get;set;}
        public virtual ICollection<ShareProductTaxGroup> TaxGroups { get; set; }
        public virtual ICollection<TaxableItem> TaxableItems { get; set; } = [];
        public virtual ICollection<ChargeItem> ChargedItems { get; set; } = [];
        public virtual ICollection<ShareProductParam> ProductParams { get; set; } = [];
        public virtual ICollection<ShareAccount> ShareAccounts {get;set;} = [];
        public virtual ICollection<ShareValue> ShareValues {get;set;} = [];
    }
}
