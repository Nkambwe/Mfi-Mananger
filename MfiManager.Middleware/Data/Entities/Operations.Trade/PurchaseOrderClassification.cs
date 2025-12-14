namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class PurchaseOrderClassification : BaseEntity {
        public string Code {get;set; }
        public string Name  {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults {get;set;}=[];
    }
}
