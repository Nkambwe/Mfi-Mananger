using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {
    public class PaymentDefault :BaseEntity {
        public PaymentMethod Method {get;set; }
        public long? BankAccountId {get;set; }
        public long? SupplierVendorId {get;set; }
        public virtual SupplierInfo SupplierInfo { get; set; }
        public long? PaymentTermsId {get;set; }
        public virtual PaymentTerm PaymentTerms { get; set; }
        public long? SupplierId {get;set; }
        public virtual  Trader SupplierVendor { get; set; }
        public long? CustomerVendorId {get;set; }
        public virtual Trader CustomerVendor {get;set; }
        /// <summary>
        /// Get/Set vendor/customer bank account to pay to/from
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }
    }
}
