namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Savings account signatory information
    /// </summary>
    public class SavingAccountSignatory : BaseEntity {
        public long AccountId { get; set; }
        /// <summary>
        /// Get/Set client code for the first signatory
        /// </summary>
        public string FirstSignatory { get; set; }
        /// <summary>
        /// Get/Set whether first signatory can be the only signatory
        /// </summary>
        public bool FirstAsOnly { get; set; }
        /// <summary>
        /// Get/Set client code for the second signatory
        /// </summary>
        public string SecondSignatory { get; set; }
        /// <summary>
        /// Get/Set whether second signatory can be the only signatory
        /// </summary>
        public bool SecondAsOnly { get; set; }
        /// <summary>
        /// Get/Set client code for the first signatory
        /// </summary>
        public string ThirdSignatory { get; set; }
        /// <summary>
        /// Get/Set whether third signatory can be the only signatory
        /// </summary>
        public bool ThirdAsOnly { get; set; }
        public virtual SavingAccount Account { get; set; }

    }
}
