using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    public class ChargeGroup : BaseEntity {
        public string SerieIdentifier {get;set; }
        public string SeriePrefix {get;set; }
        public string GroupName {get;set; }
        public int LastSeries { get; set; }
        public string Notes {get;set; }
        public virtual ICollection<TimedepositProduct> TimedepositProducts { get; set; }
        public virtual ICollection<InsuranceProduct> InsuranceProducts { get; set; }
        public virtual ICollection<ShareProduct> ShareProducts { get; set; }
        public virtual ICollection<SavingProduct> SavingProducts { get; set; }
        public virtual ICollection<LoanProduct> LoanProducts { get; set; }
        public virtual ICollection<ChargeGroupItem> ChargeGroupItems {get;set;}=[];
    }

}
