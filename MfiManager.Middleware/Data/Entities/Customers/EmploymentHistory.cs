
namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Individual's employment history
    /// </summary>
    public class EmploymentHistory : BaseEntity {
        public string Employer { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool WorkHere { get; set; }
        public string Position { get; set; }
        public decimal Earning { get; set; }
        public long? PersonId {get; set; }
        public virtual Individual Individual { get; set; }
        public long? MemberId {get; set; }
        public virtual Member Member { get; set; }
        public string Notes { get; set; }
        public override string ToString() => !string.IsNullOrEmpty(Employer) ? $"{Employer} - {Earning:#,###.00} {(WorkHere ? "(Current)" : "")}" : base.ToString();
    }
}
