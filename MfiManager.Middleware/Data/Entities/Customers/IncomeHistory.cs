using MfiManager.Middleware.Data.Entities.Customers.Support;

namespace MfiManager.Middleware.Data.Entities.Customers {
    public class IncomeHistory : BaseEntity {
        public long? PersonId {get;set;}
        public long? MemberId {get;set; }
        public string Employer {get;set; }
        public string Position {get;set; }
        public DateTime HiredOn {get;set; }
        /// Get/Set whether this is the current working place
        /// </summary>
        public bool Current {get;set; }
        public DateTime? Ended {get;set; }
        public decimal Salary {get;set; }
        public long IncomeId {get;set; }
        public virtual Individual Person { get; set; }
        public virtual Member Member { get; set; }
        public virtual Income Income { get; set; }
    }
}
