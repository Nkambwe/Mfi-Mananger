using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Operations.Reasons;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using MfiManager.Middleware.Data.Entities.Support;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Trade {

    public class Trader : TradeContact {
        public TraderType Type { get; set; }
        public bool IsSupplier { get; set; }
        public long? GroupId { get; set; }
        public long? DeliverTermsId { get; set; }
        public long? DeliveryModeId { get; set; }
        public long? ReasonId { get; set; }
        public virtual GeneralReason Reason { get; set; }
        public virtual TraderGroup Group { get; set; }
        public virtual DeliveryTerms DeliverTerms { get; set; }
        public DeliveryMode DeliveryMode { get; set; }
        public virtual ICollection<TraderTax> SalesTaxes { get; set; } = [];
        public virtual ICollection<ContactAddress> Addresses { get; set; } = [];
        public virtual ICollection<BusinessContact> Contacts { get; set; } = [];
        public virtual ICollection<TraderBankAccount> BankAccounts { get; set; } = [];
        public virtual ICollection<SalesOrderDefault> SalesOrderDefault { get; set; } = [];
        public virtual ICollection<InvoicingDefault> InvoicingDefaults { get; set; } = [];
        public virtual ICollection<DeliveryDefaults> DeliveryDefaults { get; set; }=[];
        public ICollection<PaymentDefault> VendorPaymentDefaults { get; set; } = new List<PaymentDefault>();
        public ICollection<PaymentDefault> CustomerPaymentDefaults { get; set; } = new List<PaymentDefault>();
        public virtual ICollection<PurchasingDefaults> PurchasingDefaults { get; set; } = [];
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults { get; set; } = [];
        public virtual ICollection<HeldContract> HeldContracts { get; set; } = [];
        public virtual ICollection<TraderReference> RefereceValues { get; set; } = [];
        public virtual ICollection<Card> Cards { get; set; } = [];
    }

}
