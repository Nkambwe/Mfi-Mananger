
namespace MfiManager.Middleware.Data.Entities.Accounts.Charges {
    public class ChargeItemCharge {
        public long ChargeItemId { get; set; }
        public long ChargeId { get; set; }
        public virtual ChargeItem ChargeItem { get; set; }
        public virtual Charge Charge { get; set; }
    }

}
