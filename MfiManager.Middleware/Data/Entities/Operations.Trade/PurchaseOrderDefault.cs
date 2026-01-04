using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class PurchaseOrderDefault : BaseEntity {
        /// <summary>
        /// Get/Set bank account used for central payments in cases
        /// where the main branch pays for all branch purchases
        /// </summary>
        public string MultiBranchAccount  {get;set; }
        public long SupplierId  {get;set; }
        public long? SupplierGroupId  {get;set; }
        public long? VendorId  {get;set; }
        public long? ItemGroupId  {get;set; }
        public long? DiscountGroupId  {get;set; }
        public long? PriceGroupId  {get;set; }
        public long? BankAccountId  {get;set; }
        public long? OrderClassificationId {get;set; }
        public virtual SupplierInfo Supplier { get; set; }
        public virtual Trader Vendor { get; set; }
        public virtual SupplierGroup SupplierGroup { get; set; }
        public virtual SupplierItemGroup ItemGroup { get; set; }
        public virtual DiscountGroup DiscountGroup { get; set; }
        public virtual PriceGroup PriceGroup { get; set; }
        public virtual PurchaseOrderClassification OrderClassification { get; set; }
        /// <summary>
        /// Get/Set our bank account from which we pay this vendor
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
        
    }
}
