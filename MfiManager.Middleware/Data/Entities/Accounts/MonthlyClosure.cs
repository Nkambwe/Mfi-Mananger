using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class MonthlyClosure: BaseEntity{
        public Guid YearId  {get;set;}
        public Month Month  {get;set;}
        public DateTime? ClosedOn {get;set;}

        public virtual FinancialYear Year { get; set; }
    }
}
