using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    public abstract class AccountBase : BaseEntity {
        public string LedgerNumber  {get;set;}
        public string LedgerName {get;set;}
        public AccountClassification AccountClassification {get;set;}
        public AccountCategory Category {get;set;}
        public long GroupIndex {get;set;}
        public long LedgerIndex  {get;set;}
        public AccountNature AccountNature {get;set;}

    }
}
