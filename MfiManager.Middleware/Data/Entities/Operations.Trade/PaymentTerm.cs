namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class PaymentTerm : BaseEntity {
        public string Terms {get;set; }
        public string Description {get;set; }
        public virtual ICollection<PaymentDefault> PaymentDefaults {get;set;}=[];
     }
}
