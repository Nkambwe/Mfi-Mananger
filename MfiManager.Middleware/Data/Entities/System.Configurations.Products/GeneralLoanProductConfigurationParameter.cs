using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class GeneralLoanProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "LedgerForWitholdingTax", description: "Ledger for Witholding Tax", paramType: "string")]
        public string LedgerForWitholdingTax { get; set; }
        [ConfigParam(name: "LedgerForStampDutyOnPrincipalPersonalLoans", description: "Ledger for stamp duty on personal loans principal", paramType: "string")]
        public string LedgerForStampDutyOnPrincipalPersonalLoans { get; set; }
        [ConfigParam(name: "LedgerForStampDutyOnInterestPersonalLoans", description: "Ledger for stamp duty on personal loans interest", paramType: "string")]
        public string LedgerForStampDutyOnInterestPersonalLoans { get; set; }
        [ConfigParam(name: "LedgerForStampDutyOnPrincipalGroupLoans", description: "Ledger for stamp duty on group loans principal", paramType: "string")]
        public string LedgerForStampDutyOnPrincipalGroupLoans { get; set; }
        [ConfigParam(name: "LedgerForStampDutyOnInterestGroupLoans", description: "Ledger for stamp duty on group loans interest", paramType: "string")]
        public string LedgerForStampDutyOnInterestGroupLoans { get; set; }
        [ConfigParam(name: "LedgerForStampDutyOnPrincipalBusinessLoans", description: "Ledger for stamp duty on business loans principal", paramType: "string")]
        public string LedgerForStampDutyOnPrincipalBusinessLoans { get; set; }
        [ConfigParam(name: "LedgerForStampDutyOnInterestBusinessLoans", description: "Ledger for stamp duty on business loans interest", paramType: "string")]
        public string LedgerForStampDutyOnInterestBusinessLoans { get; set; }
        [ConfigParam(name: "LedgerForOtherTax", description: "Ledger for other taxes on this loan product", paramType: "string")]
        public string LedgerForOtherTax { get; set; }
        [ConfigParam(name: "ShowDisclaimerOnLedgerCard", description: "Check whether to show disclaimer", paramType: "bool")]
        public string ShowDisclaimerOnLedgerCard { get; set; }
        [ConfigParam(name: "LedgerCardDisclaimer", description: "Ledgercard disclaimer text", paramType: "string")]
        public string LedgerCardDisclaimer { get; set; }
    }

}
