namespace MfiManager.Middleware.Data.Entities.Accounts.Currecies {
    public class Denomination : BaseEntity {
        public long CurrencyId {get;set; }
        public string Name {get;set; }
        public string Symbol {get;set; }
        public decimal Value {get;set;}
        public virtual Currency Currency { get; set; }
    }
}
