using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class ShareProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "NorminalValue", description: "Share norminal value", paramType: "decimal")]
        public string NorminalValue { get; set; }
        [ConfigParam(name: "CalculationMethod", description: "Divided calculation method", paramType: "int")]
        public string CalculationMethod { get; set; }
        [ConfigParam(name: "DividendCalculationPeriod", description: "Divided calculation period", paramType: "int")]
        public string DividendCalculationPeriod { get; set; }
        [ConfigParam(name: "CalculationInterval", description: "Divided calculation period interval type", paramType: "int")]
        public string CalculationInterval { get; set; }
        [ConfigParam(name: "DividendCalculationRate", description: "Dividend calculation percentage rate", paramType: "decimal")]
        public string DividendCalculationRate { get; set; }
        [ConfigParam(name: "LastCalculationDate", description: "Last divided calculation date", paramType: "datetime")]
        public string LastCalculationDate { get; set; }
        [ConfigParam(name: "MinimumShareCapital", description: "Minimum share capital contribution", paramType: "decimal")]
        public string MinimumShareCapital { get; set; }
        [ConfigParam(name: "DividendEarningShares", description: "Number of shares that earn dividednds", paramType: "int")]
        public string DividendEarningShares { get; set; }
        [ConfigParam(name: "LedgerForIndividualShares", description: "Ledger account for individual shares purchased", paramType: "string")]
        public string LedgerForIndividualShares { get; set; }
        [ConfigParam(name: "LedgerDividendIndividuals", description: "Ledger account for dividends on individual shares", paramType: "string")]
        public string LedgerDividendIndividuals { get; set; }
        [ConfigParam(name: "LedgerAccruedDividendIndividuals", description: "Ledger account for accrude dividends on individual shares", paramType: "string")]
        public string LedgerAccruedDividendIndividuals { get; set; }
        [ConfigParam(name: "LedgerForGroupMembersShares", description: "Ledger account for group member shares purchased", paramType: "string")]
        public string LedgerForGroupMembersShares { get; set; }
        [ConfigParam(name: "LedgerDividendGroupMembers", description: "Ledger account for dividends on group member shares", paramType: "string")]
        public string LedgerDividendGroupMembers { get; set; }
        [ConfigParam(name: "LedgerAccruedDividendGroupMembers", description: "Ledger account for accrude dividends on group member shares", paramType: "string")]
        public string LedgerAccruedDividendGroupMembers { get; set; }
        [ConfigParam(name: "LedgerForBusinessShares", description: "Ledger account for business shares purchased", paramType: "string")]
        public string LedgerForBusinessShares { get; set; }
        [ConfigParam(name: "LedgerDividendBusinesses", description: "Ledger account for dividends on business shares", paramType: "string")]
        public string LedgerDividendBusinesses { get; set; }
        [ConfigParam(name: "LedgerAccruedDividendBusinesses", description: "Ledger account for accrude dividends on business shares", paramType: "string")]
        public string LedgerAccruedDividendBusinesses { get; set; }
        [ConfigParam(name: "LedgerForSharesRedemption", description: "Ledger account for share redemption", paramType: "string")]
        public string LedgerForSharesRedemption { get; set; }
        [ConfigParam(name: "LedgerForShareCheques", description: "Ledger account for share cheques", paramType: "string")]
        public string LedgerForShareCheques { get; set; }
        [ConfigParam(name: "ChargeWitholdingTaxOnDividends", description: "Check whether product charges witholding tax on dividends", paramType: "bool")]
        public string ChargeWitholdingTaxOnDividends { get; set; }
        [ConfigParam(name: "LedgerForWitholdingTax", description: "Ledger for Witholding Tax", paramType: "string")]
        public string LedgerForWitholdingTax { get; set; }
        [ConfigParam(name: "LedgerForOtherTax", description: "Ledger account for other taxes", paramType: "string")]
        public string LedgerForOtherTax { get; set; }
     }

}
