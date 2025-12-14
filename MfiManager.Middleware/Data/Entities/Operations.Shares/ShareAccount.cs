using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Shares {

    public class ShareAccount : BaseEntity {
        public string AccountNumber {get;set; }
        public DateTime OpenedOn {get;set; }
        public int Shares {get;set; }
        public decimal TotalValue {get;set; }
        public DateTime? ClosedOn {get;set;}
        public long BranchId {get;set; }
        public long ProductId {get;set; }
        public long? IndividualId {get;set; }
        public long? MemberId {get;set; }
        public virtual Branch Branch { get; set; }
        public virtual ShareProduct Product { get; set; }
        public virtual Individual IndividualClient { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<ShareTransactionLedger> ShareTransactions {get;set;}=[];
        public virtual ICollection<DividendTransactionLedger> DividendTransactions {get;set;}=[];

    }

}
