using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Shares {
    public class ShareValue : BaseEntity {
        public long ProductId {get;set; }
        public bool Current {get;set; }
        public decimal PerValue {get;set; }
        public DateTime AddedOn {get;set; }
        public virtual  ShareProduct Product { get; set; }
        public virtual ICollection<ShareTransactionLedger> ShareTransactions {get;set;}=[];
    }
}
