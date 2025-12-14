using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {

    public class SupplierInfo : TradeContact {
        public int Employees { get; set; }
        public string DeliveryLocation { get; set; }
        public VendorType Type { get; set; }
        /// <summary>
        /// Get/Set whether vendor is a client
        /// </summary>
        public bool IsClient { get; set; }
        public string ClientCode { get; set; }
        public long? DeliverTermsId { get; set; }
        public long? DeliveryModeId { get; set; }
        public long? SupplierGroupId { get; set; }
        public virtual SupplierGroup SupplierGroup { get; set; }
        public virtual DeliveryTerms DeliverTerms { get; set; }
        public virtual DeliveryMode DeliveryMode { get; set; }
        public virtual ICollection<SupplierTax> SalesTaxes { get; set; }=[];
        public virtual ICollection<BusinessContact> Contacts { get; set; }=[];
        public virtual ICollection<ContactAddress> Addresses { get; set; }=[];
        public virtual ICollection<SupplierBankAccount> BankAccounts { get; set; }=[];
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults { get; set; }=[];
        public virtual ICollection<PaymentDefault> PaymentDefaults { get; set; }=[];
        public virtual ICollection<HeldContract> HeldContracts { get; set; }=[];
        public virtual ICollection<SupplierReference> SupplierReferences { get; set; }=[];
        public virtual ICollection<SuppliedBranch> SuppliedBranches { get; set; }=[];
    }
}
