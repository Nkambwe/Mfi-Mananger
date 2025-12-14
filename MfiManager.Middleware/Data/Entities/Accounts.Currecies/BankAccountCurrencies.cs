using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;

namespace MfiManager.Middleware.Data.Entities.Accounts.Currecies {
    public class BankAccountCurrencies {
        public long BankAccountId {get;set;}
        public long CurrencyId {get;set;}

        public virtual Currency Currency  {get;set;}
        public virtual BankAccount BankAccount {get;set;}
    }
}
