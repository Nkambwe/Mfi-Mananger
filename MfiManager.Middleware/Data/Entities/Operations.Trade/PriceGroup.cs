using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    /// <summary>
    /// Price group like Major Purchase, Major Sales, Wholesale Purchase, Wholesale Selling, Retail Purchase, Retail Selling, Inter company Purchase, Inter company Selling
    /// Domestic Suppliers, International Suppliers
    /// </summary>
    public class PriceGroup : BaseEntity {
        public string Code {get;set; }
        public string Group {get;set; }
        public GroupType Type {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults {get;set; }=[];
        public virtual ICollection<SalesOrderDefault> SalesOrderDefaults {get;set;}=[];
    }

}
