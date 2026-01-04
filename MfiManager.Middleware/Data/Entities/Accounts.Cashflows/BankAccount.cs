using MfiManager.Middleware.Data.Entities.Accounts.Currecies;
using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Data.Entities.Operations.Trade;
using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using MfiManager.Middleware.Data.Helpers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts.Cashflows {

    public class BankAccount : BaseEntity, IEntityAccessSupported {
        /// <summary>
        /// Get/Set client or supplier code
        /// </summary>
        public string HolderCode  {get;set;}
        [Encryptable("Account Name")]
        public string AccountName  {get;set;}
        [Encryptable("Account Number")]
        public string AccountNumber   {get;set;}
        /// <summary>
        /// Get/Set bank IBAN number
        /// </summary>
        public string IbanNumber  {get;set;}
        /// <summary>
        /// Get/Set bank SWIFT code
        /// </summary>
        public string SwiftNumber  {get;set;}
        /// <summary>
        /// Get/Set type of person owing this account e.g. Customer account, vendor account or business account
        /// </summary>
        public AccountHolder AccountFor  {get;set;}
        public Operation Operations  {get;set;}
        public bool MultiCurrency   {get;set;}
        /// <summary>
        /// Get/Set the number of days between withdraws
        /// </summary>
        public int WithdrawInterval   {get;set;}
        public Interval Duration  {get;set;}
        public long? LedgerId  {get;set;}
        public bool HasBook  {get;set;}
        public bool Active   {get;set;}
        [Encryptable("Credit Limit")]
        public decimal CreditLimit  {get;set;}
        public bool ExcludeBranches  {get;set;}
        public long BankBranchId   {get;set;}
        public virtual BankBranch BankBranch { get; set; }
        public virtual LedgerAccount LedgerAccount { get; set; }
        public virtual ICollection<ChequeBook> Books  {get;set;}=[];
        public virtual ICollection<BankAccountCurrencies> Currencies  {get;set;}=[];
        public virtual ICollection<BankLedger> BankTransaction  {get;set;}=[];
        public virtual ICollection<SupplierBankAccount> Suppliers  {get;set;}=[];
        public virtual ICollection<TraderBankAccount> Traders  {get;set;}=[];
        public virtual ICollection<SalesOrderDefault> SalesOrderDefaults  {get;set;}=[];
        public virtual ICollection<PurchaseOrderDefault> PurchaseOrderDefaults  {get;set;}=[];
        public virtual ICollection<PaymentDefault> DefaultVendorPayments {get;set;}=[];

    }

}
