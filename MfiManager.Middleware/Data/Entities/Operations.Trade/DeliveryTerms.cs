using MfiManager.Middleware.Data.Entities.Operations.Vendors;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class DeliveryTerms : BaseEntity {
        public string Code {get;set; }
        public string Description {get;set; }
        public virtual ICollection<Trader> Traders {get;set; }=[];
        public virtual ICollection<SupplierInfo> Suppliers {get;set;}=[];
    }
}
