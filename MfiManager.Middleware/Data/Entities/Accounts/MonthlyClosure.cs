using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts {

    public class MonthlyClosure: BaseEntity {
        public Month Month  {get;set;}
        public DateTime StartDate {get;set;}
        public DateTime CloseDate {get;set;}
        public long YearId  {get;set;}
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual ICollection<Ledger> GeneralLedgerTransactions  {get;set;}=[];
    }

}
