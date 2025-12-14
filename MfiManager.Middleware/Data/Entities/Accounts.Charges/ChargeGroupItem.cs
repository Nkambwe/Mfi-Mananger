namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    public class ChargeGroupItem : BaseEntity {
        public string Code {get;set; }
        public string ChargeName {get;set; }
        public bool IsRated  {get;set; }
        public decimal Rate {get;set; }
        public decimal FlatAmount {get;set; }
        public string Notes {get;set; }
        public long ChargeGroupId {get;set; }
        public virtual ChargeGroup ChargeGroup {get;set; }
    }

}
