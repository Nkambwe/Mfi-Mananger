using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Taxes {
    /// <summary>
    /// Class represents tax group eg. VAT, Income Tax,Withholding tax etc.
    /// </summary>
    public class TaxGroup :BaseEntity {
        public string Code {get;set; }
        public string CustomSeries {get;set; }
        public string Description {get;set; }
        public virtual ICollection<ProductTaxGroup> Products {get;set; } = [];
        public virtual ICollection<JournalTypeTaxGroup> JournalTypes {get;set; } = [];
        public virtual ICollection<Tax> Taxes {get;set;} = [];
    }

}
