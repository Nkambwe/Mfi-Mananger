
using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.System.Configurations;

namespace MfiManager.Middleware.Data.Entities.Operations.Products {

    public class Product : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Disabled { get; set; }
        public bool VatInclusive { get; set; }
        public bool UseChargeGroups { get; set; }
        public long ProductTypeId { get; set; }
        public long? TaxGroupId { get; set; }
        public long? ChargeGroupId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual ChargeGroup ChargeGroup { get; set; }
        public virtual ICollection<ChargeStage>  ChargeStages {get;set;}
        public virtual ICollection<ProductTaxGroup> TaxGroups { get; set; }
        public virtual ICollection<TaxableItem> TaxableItems { get; set; } = [];
        public virtual ICollection<ChargeItem> ChargedItems { get; set; } = [];
        public virtual ICollection<ProductConfiguration> Configurations { get; set; } = [];
        public virtual ICollection<SavingProduct> SavingProducts { get; set; } = [];
        public virtual ICollection<ShareProduct> ShareProducts { get; set; } = [];
        public virtual ICollection<LoanProduct> LoanProducts { get; set; } = [];
        public virtual ICollection<InsuranceProduct> InsuranceProducts { get; set; } = [];
        public virtual ICollection<TimedepositProduct> TimedepositProducts { get; set; } = [];
  
    }

}
