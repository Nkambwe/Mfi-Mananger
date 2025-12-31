namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class GeneralLoanProductConfiguration { 
        /// <summary>
        /// Get Or Set witholding tax code attached to this product
        /// </summary>
        //public string WitholdingTaxCode { get; set; } 
        /// <summary>
        /// Get Or Set ledger for Witholding Tax
        /// </summary>
        public string LedgerForWitholdingTax { get; set; } = "";
        /// <summary>
        /// Get Or Set stamp duty code for mortgage deeds attached to this product
        /// </summary>
        //public string StampDutyOnMortgageCode { get; set; }
        /// <summary>
        /// Get Or Set stamp duty code for principal attached to this product
        /// </summary>
        //public string StampDutyOnProncipalCode { get; set; }
        /// <summary>
        /// Get Or Set stamp duty code for interest attached to this product
        /// </summary>
        //public string StampDutyOnInterestCode { get; set; }
        /// <summary>
        /// Get Or Set ledger for stamp duty on personal loans principal
        /// </summary>
        public string LedgerForStampDutyOnPrincipalPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on personal loans interest
        /// </summary>
        public string LedgerForStampDutyOnInterestPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on group loans principal
        /// </summary>
        public string LedgerForStampDutyOnPrincipalGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on group loans interest
        /// </summary>
        public string LedgerForStampDutyOnInterestGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on business loans principal
        /// </summary>
        public string LedgerForStampDutyOnPrincipalBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on business loans interest
        /// </summary>
        public string LedgerForStampDutyOnInterestBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for other taxes
        /// </summary>
        public string LedgerForOtherTax { get; set; } = "";
        /// <summary>
        /// Get Or Set ledgercard disclaimer text
        /// </summary>
        public string LedgerCardDisclaimer { get; set; } = "";

        
    }
}
