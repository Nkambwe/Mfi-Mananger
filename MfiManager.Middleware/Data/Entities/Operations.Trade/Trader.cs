using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using MfiManager.Middleware.Data.Entities.Customers.Support;
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
        public virtual Reason Reason { get; set; }
        public virtual TraderGroup Group { get; set; }
        public virtual DeliveryTerms DeliverTerms { get; set; }
        public DeliveryMode DeliveryMode { get; set; }
        public virtual ICollection<TraderTax> SalesTaxes { get; set; } = [];
        public virtual ICollection<ContactAddress> Addresses { get; set; } = [];
        public virtual ICollection<BusinessContact> Contacts { get; set; } = [];
        public virtual ICollection<TraderBankAccount> BankAccounts { get; set; } = [];
        public virtual ICollection<SalesOrderDefault> SalesOrderDefault { get; set; } = [];
        public virtual ICollection<PaymentDefault> VendorPaymentDefaults { get; set; } = [];
        public virtual ICollection<PaymentDefault> CustomerPaymentDefaults { get; set; } = [];
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults { get; set; } = [];
        public virtual ICollection<HeldContract> HeldContracts { get; set; } = [];
        public virtual ICollection<TraderReference> RefereceValues { get; set; } = [];
        public virtual ICollection<Card> Cards { get; set; } = [];
    }

}
