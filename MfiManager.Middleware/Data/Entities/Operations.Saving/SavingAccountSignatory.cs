namespace MfiManager.Middleware.Data.Entities.Operations.Saving {
    /// <summary>
    /// Savings account signatory information
    /// </summary>
    public class SavingAccountSignatory : BaseEntity {
        public long SavingAccountId { get; set; }
        /// <summary>
        /// Get/Set client code for the first signatory
        /// </summary>
        public string FirstSignatory { get; set; }
        /// <summary>
        /// Get/Set client signature for the first signatory
        /// </summary>
        public string FirstSignature { get; set; }
        /// <summary>
        /// Check whether first signatory can be the only signatory
        /// </summary>
        public bool FirstCanSignAlone { get; set; }
        /// <summary>
        /// Get/Set client code for the second signatory
        /// </summary>
        public string SecondSignatory { get; set; }
        /// <summary>
        /// Get/Set client signature for the second signatory
        /// </summary>
        public string SecondSignature { get; set; }
        /// <summary>
        /// Check whether second signatory can be the only signatory
        /// </summary>
        public bool SecondCanSignAlone { get; set; }
        /// <summary>
        /// Get/Set client code for the first signatory
        /// </summary>
        public string ThirdSignatory { get; set; }
        /// <summary>
        /// Get/Set client signature for the third signatory
        /// </summary>
        public string ThirdSignature { get; set; }
        /// <summary>
        /// Check whether third signatory can be the only signatory
        /// </summary>
        public bool ThirdCanSignAlone { get; set; }

        public virtual SavingAccount SavingAccount { get; set; }

    }
}
