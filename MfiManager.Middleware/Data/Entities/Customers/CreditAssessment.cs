namespace MfiManager.Middleware.Data.Entities.Customers {
    /// <summary>
    /// Credit assessment for a client
    /// </summary>
    public class CreditAssessment : BaseEntity {
        public bool IsWorthy { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal MaximumAllowed { get; set; }
        public DateTime AssessedOn { get; set; }
        public DateTime? ConfirmedOn { get; set; }
        /// <summary>
        /// Get/Set last validity date of assessment
        /// </summary>
        public DateTime? ReviewOn { get; set; }
        public string ConfirmedBy { get; set; }
        public long PersonId { get; set; }
        public virtual Individual Individual { get; set; }

    }
}
