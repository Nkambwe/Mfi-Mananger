using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    /// <summary>
    /// Discount group like High volume customer, Medium volume customer, low volume customer, High volume supplier, Medium volume supplier, Low volume supplier
    /// </summary>
    public class DiscountGroup : BaseEntity {
        public string Code {get;set; }
        public string Group {get;set; }
        public GroupType Type {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults {get;set; }
        public virtual ICollection<SalesOrderDefault> SalesOrderDefaults {get;set;}
    }
}
