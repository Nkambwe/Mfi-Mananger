using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class GeneralSavingProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "ChargeAccountOpeningFees", description: "Check whether product charges payment of fee for opening savings account", paramType: "bool")]
        public string ChargeAccountOpeningFees { get; set; }
        [ConfigParam(name: "SetAccountOpeningFeesPerAccountType", description: "Check whether product charges payment of fee for opening savings account based on a type of account [see Savings account type charges]", paramType: "bool")]
        public string SetAccountOpeningFeesPerAccountType { get; set; }
        [ConfigParam(name: "ChargeAccountClosureFees", description: "Check whether product charges payment of fee for closing savings account", paramType: "bool")]
        public string ChargeAccountClosureFees { get; set; }
        [ConfigParam(name: "SetAccountClosingFeesPerAccountType", description: "Check whether product charges payment of fee for closing savings account based on a type of account [see Savings account type charges]t", paramType: "bool")]
        public string SetAccountClosingFeesPerAccountType { get; set; }
        [ConfigParam(name: "RequireApprovalForWithdrawsAboveCashierLimit", description: "Check whether product requires supervisor approvals for withdraws above cashier limit", paramType: "bool")]
        public string RequireApprovalForWithdrawsAboveCashierLimit { get; set; }
        [ConfigParam(name: "AuthoritiesToWithdrawAboveCashierLimit", description: "List of authorities that can approve withdraws above cashier limit", paramType: "array")]
        public string AuthoritiesToWithdrawAboveCashierLimit { get; set; }
        [ConfigParam(name: "DisplayChronologically", description: "Check whether transactions are to be displayed starting with latest", paramType: "bool")]
        public string DisplayChronologically { get; set; }
        [ConfigParam(name: "RequireSupervisorApprovalToActivateDormantAccounts", description: "Check whether product requires supervisor approval to activate dormant accounts", paramType: "bool")]
        public string RequireSupervisorApprovalToActivateDormantAccounts { get; set; }
        [ConfigParam(name: "AuthoritiesToActivateOfDormantAccounts", description: "List of authorities that can approve activation of dormant accounts", paramType: "array")]
        public string AuthoritiesToActivateOfDormantAccounts { get; set; }
        [ConfigParam(name: "BookSavingsToGeneralLedger", description: "Check whether savings transactions are also booked to the general ledger", paramType: "bool")]
        public string BookSavingsToGeneralLedger { get; set; }
    }

}
