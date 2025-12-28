using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class TimeDepoisitProductConfiguration {
        /// <summary>
        /// Get Or Set share norminal value
        /// </summary>
        public decimal NorminalValue { get; set; } = 0;
        /// <summary>
        /// Get Or Set divided calculation method
        /// </summary>
        public DividendCalculationMethod CalculationMethod { get; set; } = DividendCalculationMethod.None;
        /// <summary>
        /// Get Or Set divided calculation period
        /// </summary>
        public int Period { get; set; } = 0;
        /// <summary>
        /// Get Or Set divided calculation period interval type
        /// </summary>
        public Interval Interval { get; set; } = Interval.Months;
        /// <summary>
        /// Get Or Set divided calculation rate
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// Get Or Set last divided calculation date
        /// </summary>
        public DateTime? LastCalculationDate { get; set; }
        /// <summary>
        ///  Get Or Set minimum share capital contribution
        /// </summary>
        public decimal MinimumShareCapital { get; set; }
        /// <summary>
        /// Get Or Set the number of shares that earn dividednds
        /// </summary>
        public string DividendEarningShares { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for individual shares purchased
        /// </summary>
        public string LedgerForIndividualShares { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for dividends on individual shares
        /// </summary>
        public string LedgerDividendIndividuals { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for accrude dividends on individual shares
        /// </summary>
        public string LedgerAccruedDividendIndividuals { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for group member shares purchased
        /// </summary>
        public string LedgerForGroupMembersShares { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for dividends on group member shares
        /// </summary>
        public string LedgerDividendGroupMembers { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for accrude dividends on groups shares
        /// </summary>
        public string LedgerAccruedDividendGroupMembers { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for business shares purchased
        /// </summary>
        public string LedgerForBusinessShares { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for dividends on business shares
        /// </summary>
        public string LedgerDividendBusinesses { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for accrude dividends on business shares
        /// </summary>
        public string LedgerAccruedDividendBusinesses { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for share redemption
        /// </summary>
        public string LedgerForSharesRedemption { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for share cheques
        /// </summary>
        public string LedgerForShareCheques { get; set; } = "";
        /// <summary>
        ///  Get or Set value indicating whether product charges witholding tax on dividends
        /// </summary>
        public bool ChargeWitholdingTaxOnDividends { get; set; } = false;
        /// <summary>
        /// Get Or Set witholding tax code attached to this product [See Witholding tax]
        /// </summary>
        public string WitholdingTaxCode { get; set; }
        /// <summary>
        /// Get Or Set ledger for Witholding Tax
        /// </summary>
        public string LedgerForWitholdingTax { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for other taxes
        /// </summary>
        public string LedgerForTax { get; set; } = "";
    }
}
