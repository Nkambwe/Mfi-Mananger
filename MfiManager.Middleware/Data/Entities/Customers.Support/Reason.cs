using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Support;

namespace MfiManager.Middleware.Data.Entities.Customers.Support {

    public class Reason : BaseEntity {
        public string SeriesNumber { get; set; }
        public string Description { get; set; }
        public long ReasonCategoryId { get; set; }
        public string Notes { get; set; }
        public virtual ReasonCategory ReasonCategory { get; set; }
        public virtual ICollection<Trader> Traders { get; set; } = [];
        public virtual ICollection<ExitRecord> ExitedClients { get; set; } = [];
        /// <summary>
        /// Get/Set black listed clients reasons
        /// </summary>
        public virtual ICollection<BlackListedCustomer> BlackListedCustomers { get; set; } = [];
        public virtual ICollection<HeldContract> HeldContracts { get; set; } = [];
        public virtual ICollection<JournalType> Journals {get;set;}=[];
        public virtual ICollection<VoucherType> Vouchers {get;set;}=[];


    }
}
