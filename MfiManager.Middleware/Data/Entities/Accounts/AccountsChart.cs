using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts {

    public class AccountsChart : BaseEntity  {
        public string ChartName{get;set;}
        public string Description {get;set;}
        public ChartType ChartType{get;set;}
        public virtual ICollection<Branch> Branches {get;set;}=[];
        public virtual ICollection<LedgerAccount> LedgerAccounts {get;set;}=[];
    }

}
