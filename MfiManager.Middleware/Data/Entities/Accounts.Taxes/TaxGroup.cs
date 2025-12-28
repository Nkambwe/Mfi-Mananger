using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Taxes {
    /// <summary>
    /// Class represents tax group eg. VAT, Income Tax,Withholding tax etc.
    /// </summary>
    public class TaxGroup :BaseEntity {
        public string SerieIdentifier {get;set; }
        public string SeriePrefix {get;set; }
        public string Description {get;set; }
        public int LastSeries { get; set; }
        public string Notes {get;set; }
        public virtual ICollection<TimedepositProductTaxGroup> TimedepositProducts {get;set; } = [];
        public virtual ICollection<InsuranceProductTaxGroup> InsuranceProducts {get;set; } = [];
        public virtual ICollection<ShareProductTaxGroup> ShareProducts {get;set; } = [];
        public virtual ICollection<LoanProductTaxGroup> LoanProducts {get;set; } = [];
        public virtual ICollection<SavingProductTaxGroup> SavingProducts {get;set; } = [];
        public virtual ICollection<JournalTypeTaxGroup> JournalTypes {get;set; } = [];
        public virtual ICollection<Tax> Taxes {get;set;} = [];
    }

}
