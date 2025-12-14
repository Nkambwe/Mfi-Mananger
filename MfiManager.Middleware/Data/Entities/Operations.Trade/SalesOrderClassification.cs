namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class SalesOrderClassification : BaseEntity {
        public string Code {get;set; }
        public string Name  {get;set; }
        public string Notes {get;set; }
        public virtual ICollection<SalesOrderDefault> SalesOrderDefaults {get;set;}=[];
    }

}
