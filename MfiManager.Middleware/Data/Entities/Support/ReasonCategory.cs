using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Entity that has some reasons eg. Bank reasons (BAR), Exit reasons (EXR)
    /// </summary>
    public class ReasonCategory : BaseEntity {
        /// <summary>
        /// Get Or Set reason type
        /// </summary>
        public string Code  {get;set;}
        /// <summary>
        /// Get Or Set reason type
        /// </summary>
        public string SeriesIdentifier  {get;set;}
        public string CustomSeries  {get;set;}
        public string Description   {get;set;}
        public string Notes  {get;set;}
        public virtual ICollection<Reason> Reasons  {get;set;}=[];
        public virtual ICollection<JournalType> Journals {get;set;}=[];
        public virtual ICollection<VoucherType> Vouchers {get;set;}=[];

    }
}
