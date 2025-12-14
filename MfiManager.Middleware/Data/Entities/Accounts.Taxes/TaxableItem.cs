
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Accounts.Taxes {
    public class TaxableItem : BaseEntity {
        public string ItemCode {get;set; }
        public string Item {get;set; }
        public bool Suspend {get;set; }
        public DateTime? Started {get;set;}
        public long TaxId {get;set; }
        public long ProductId {get;set; }
        public virtual Tax Tax { get; set; }
        public virtual Product Product { get; set; }
    }
}
