namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class GeneralSavingProductConfiguration {
        /// <summary>
        /// Get or Set value indicating whether product charges payment of fee for opening savings account
        /// </summary>
        public bool ChargeAccountOpeningFees { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product charges payment of fee for opening savings account based on a type of account [see Savings account type charges]
        /// </summary>
        public bool SetAccountOpeningFeesPerAccountType { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product charges payment of fee for closing savings account
        /// </summary>
        public bool ChargeAccountClosureFees { get; set; } = false;
        /// <summary>
        /// Get or Set value indicating whether product charges payment of fee for closing savings account based on a type of account [see Savings account type charges]
        /// </summary>
        public bool SetAccountClosingFeesPerAccountType { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product requires supervisor approvals for withdraws above cashier limit
        /// </summary>
        public bool RequireApprovalForWithdrawsAboveCashierLimit { get; set; } = false;
        /// <summary>
        /// Get or Set list of authorities that can approve withdraws above cashier limit
        /// </summary>
        public List<string> AuthoritiesToWithdrawAboveCashierLimit { get; set; } = ["Manager", "Supervisor"];
        /// <summary>
        /// Get or Set value indicating whether transactions are to be displayed starting with latest
        /// </summary>
        public bool DisplayChronologically { get; set; } = false;
        /// <summary>
        ///  Get or Set value indicating whether product requires supervisor approval to activate dormant accounts
        /// </summary>
        public bool RequireSupervisorApprovalToActivateDormantAccounts { get; set; } = false;
        /// <summary>
        /// Get or Set list of authorities that can approve activation of dormant accounts
        /// </summary>
        public List<string> AuthoritiesToActivateOfDormantAccounts { get; set; } = ["Manager", "Supervisor"];
        /// <summary>
        /// Get or Set value indicating whether savings transactions are also booked to the general ledger
        /// </summary>
        public bool BookSavingsToGeneralLedger { get; set; } = true;
    }
}
