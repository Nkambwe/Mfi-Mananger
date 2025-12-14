namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Savings account interest offered record
    /// </summary>
    public class SavingAccountInterest : BaseEntity {
        public long AccountId { get; set; }
        public DateTime TransDate { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of January
        /// </summary>
        public decimal January { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of February
        /// </summary>
        public decimal February { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of March
        /// </summary>
        public decimal March { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of April
        /// </summary>
        public decimal April { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of May
        /// </summary>
        public decimal May { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of June
        /// </summary>
        public decimal June { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of July
        /// </summary>
        public decimal July { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of August
        /// </summary>
        public decimal August { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of September
        /// </summary>
        public decimal September { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of October
        /// </summary>
        public decimal October { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of November
        /// </summary>
        public decimal November { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of December
        /// </summary>
        public decimal December { get; set; }

        public decimal TotalAmount { get; set; }
        public virtual SavingAccount Account { get; set; }
    }

}
