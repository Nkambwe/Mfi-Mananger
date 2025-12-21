using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Accounts {
    public class FinancialYear : BaseEntity {
        /// <summary>
        /// Financial Year code eg.YR01
        /// </summary>
        public string Code  { get; set; }
        /// <summary>
        /// Financial year name eg.2014, 2015 or a combination of years eg.2014-2015, 2015-2016
        /// </summary>
        public string YearName  { get; set; }
        /// <summary>
        /// Number of months in a financial year eg.12,13
        /// </summary>
        public Period Period { get; set; }
        /// <summary>
        /// First month of financial year
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// First month of financial year
        /// </summary>
        public string EndDate { get; set; }
        /// <summary>
        /// Financial year is closed
        /// </summary>
        public bool Closed  { get; set; }
        /// <summary>
        /// Branch this financial year applies to 
        /// </summary>
        public long? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<MonthlyClosure> MonthlyClosures {get;set;}=[];
    }
}
