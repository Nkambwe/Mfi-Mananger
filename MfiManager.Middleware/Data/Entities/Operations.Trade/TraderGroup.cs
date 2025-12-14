using MfiManager.Middleware.Data.Entities.Customers;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class TraderGroup : ContactGroup {
        public virtual ICollection<Trader> Traders { get; set; }

    }
}
