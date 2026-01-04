namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Savings account interest offered record
    /// </summary>
    public class SavingAccountInterest : BaseEntity {
        public long SavingAccountId { get; set; }

        public DateTime CalculationDate { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of January
        /// </summary>
        public decimal JanuaryInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of February
        /// </summary>
        public decimal FebruaryInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of March
        /// </summary>
        public decimal MarchInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of April
        /// </summary>
        public decimal AprilInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of May
        /// </summary>
        public decimal MayInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of June
        /// </summary>
        public decimal JuneInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of July
        /// </summary>
        public decimal JulyInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of August
        /// </summary>
        public decimal AugustInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of September
        /// </summary>
        public decimal SeptemberInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of October
        /// </summary>
        public decimal OctoberInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of November
        /// </summary>
        public decimal NovemberInterest { get; set; }
        /// <summary>
        /// Get/Set account balance for the month of December
        /// </summary>
        public decimal DecemberInterest { get; set; }
        /// <summary>
        /// Get/Set total amount to calculated
        /// </summary>
        public decimal TotalAmount { get; set; }

        public virtual SavingAccount SavingAccount { get; set; }
    }

}
