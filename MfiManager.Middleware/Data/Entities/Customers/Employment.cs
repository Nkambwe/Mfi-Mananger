
namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Individual's employment history
    /// </summary>
    public class Employment : BaseEntity {
        public string Person { get; set; }
        public string Employer { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Ended { get; set; }
        public bool WorkHere { get; set; }
        public string Position { get; set; }
        public decimal Earning { get; set; }
        public override string ToString() => !string.IsNullOrEmpty(Employer) ? $"{Employer} - {Earning:#,###.00} {(WorkHere ? "(Current)" : "")}" : base.ToString();
    }
}
