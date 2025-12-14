using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class SalesOrderDefault : BaseEntity {
        public string Warehouse {get;set; }
        public long VendorId {get;set; }
        public long? PriceGroupId {get;set; }
        public long? DiscountGroupId {get;set; }
        public long? OrderClassificationId {get;set; }
        public long? BankAccountId {get;set; }
        public virtual Trader Vendor { get; set; }
        public virtual DiscountGroup DiscountGroup { get; set; }
        public virtual PriceGroup PriceGroup { get; set; }
        public virtual SalesOrderClassification OrderClassification { get; set; }
        /// <summary>
        /// Get/Set customer bank account from which we're paid
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }

}
