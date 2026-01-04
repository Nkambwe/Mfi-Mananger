using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;

namespace MfiManager.Middleware.Data.Entities.Operations.Vendors {
    public class SupplierBankAccount {
        public long SupplierId {get;set;}
        public long BankAccountId {get;set;}
        public virtual BankAccount BankAccount { get; set; }
        public virtual SupplierInfo Supplier { get; set; }
    }
}
