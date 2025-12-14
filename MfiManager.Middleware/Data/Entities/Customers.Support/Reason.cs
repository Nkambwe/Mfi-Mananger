using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Support;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    public class Reason : BaseEntity {
        /// <summary>
        /// Get Or Set reason type
        /// </summary>
        public string Code { get; set; }
        public string Description { get; set; }
        public long ReasonCategoryId { get; set; }
        public string Notes { get; set; }
        public virtual ReasonCategory Category { get; set; }
        public virtual ICollection<Trader> Customers { get; set; } = [];
        public virtual ICollection<ExitRecord> ExitedClients { get; set; } = [];
        /// <summary>
        /// Get/Set black listed clients reasons
        /// </summary>
        public virtual ICollection<BlackListedCustomer> Flags { get; set; } = [];
        public virtual ICollection<HeldContract> HeldContracts { get; set; } = [];

    }
}
