using MfiManager.Middleware.Data.Entities.Operations.Loans;

namespace MfiManager.Middleware.Data.Entities.Accounts.Currecies {
    public class Currency: BaseEntity {
        public string Code {get;set; }
        public string Name {get;set; }
        public string SmallUnit {get;set; }
        public string Symbol {get;set; }
        public int Precision {get;set; }
        public int Round {get;set; }
        public bool BaseCurrency {get;set;}
        public string Country {get;set; }
        public bool System {get;set; }
        public virtual ICollection<Denomination> Denominations {get;set;} = [];
        public virtual ICollection<ExchangeRate> ExchangeRates {get;set;} = [];
        public virtual ICollection<LedgerAccount> LedgerAccounts {get;set;} = [];
        public virtual ICollection<BankAccountCurrencies> BankAccounts {get;set;} = [];
        public virtual ICollection<RevolvingFund> RevolvingFunds {get;set;} = [];

        public override string ToString() => $"{Id}::{(Code ?? string.Empty).Trim()}";

        public override bool Equals(object otherCurrency) {

            if (otherCurrency is not Currency)
                return false;

            if (ReferenceEquals(this, otherCurrency))
                return true;

            var currency = (Currency)otherCurrency;

            return currency.Id.Equals(Id);
        }

        public override int GetHashCode() => IsNew()? base.ToString().GetHashCode() ^ 31 : ToString().GetHashCode() ^ 3;

        public static bool operator ==(Currency thisCurrency, Currency thatCurrency) => thisCurrency?.Equals(thatCurrency) ?? Equals(thatCurrency, null);

        public static bool operator !=(Currency thisCurrency, Currency thatCurrency) => !(thisCurrency == thatCurrency);

    }
}
