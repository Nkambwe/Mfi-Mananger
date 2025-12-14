using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Timedeposit {
    /// <summary>
    /// Interest rate for timedeposit product
    /// </summary>
    public class TimedepositRate : BaseEntity {
        public long ProductId {get;set; }
        public decimal PercentageRate {get;set; }
        public DateTime Started {get;set; }
        public DateTime? Ended {get;set;}
        public virtual TimedepositProduct Product { get; set; }
    }
}
