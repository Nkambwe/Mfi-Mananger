using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    public class ChargeGroup : BaseEntity {
        public string Code {get;set; }
        public string Group {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<Product> Products {get;set; }=[];
        public virtual ICollection<ChargeGroupItem> ChargeGroupItems {get;set;}=[];
    }

}
