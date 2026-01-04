
using MfiManager.Middleware.Data.Helpers;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class TransactionConfigurationParameter : IConfigurationParameter {
        [ConfigParam(name: "MultiBranch", description: "Check whether system is multi-branch", paramType:"bool")]
        public string MultiBranch { get; set; }
        [ConfigParam(name: "YearPeriod", description: "Financial year period eg.12 or 13 months", paramType:"int")]
        public string YearPeriod { get; set; }
        [ConfigParam(name: "YearStarts", description: "First month of financial year", paramType:"string")]
        public string YearStarts { get; set; }
        [ConfigParam(name: "YearEnds", description: "Last month of financial year", paramType:"string")]
        public string YearEnds { get; set; }
        [ConfigParam(name: "DefaultChart", description: "Default chart of accounts", paramType:"string")]
        public string DefaultChart { get; set; }
        [ConfigParam(name: "ChartType", description: "Type of chart of accounts used", paramType:"string")]
        public string ChartType { get; set; }
        [ConfigParam(name: "MustApproveDirectPosting", description: "Make approval of directly posted/manual posting entries mandatory", paramType:"bool")]
        public string MustApproveDirectPosting { get; set; }
        [ConfigParam(name: "IncludeUnapprovedTransactions", description: "Check whether to include unapproved direct/manually posted unapproved transactions when closing day", paramType:"false")]
        public string IncludeUnapprovedTransactions { get; set; }
        [ConfigParam(name: "AutomaticallyPrintReportAfterClosure", description: "Check whether to automatically  print day's transaction report after closure", paramType:"bool")]
        public string AutomaticallyPrintReportAfterClosure { get; set; }
        [ConfigParam(name: "AuthorizedApproval", description: "User code for person authorized to approve directly posted entries", paramType:"bool")]
        public string AutomaticApprovalOfDirectPosting { get; set; }
        [ConfigParam(name: "MustPerformDayClosure", description: "Make day closure mandatory", paramType:"bool")]
        public string MustPerformDayClosure { get; set; }
        [ConfigParam(name: "CanPostInClosedPeriod", description: "Check whether users are allowed to post in closed periods", paramType:"bool")]
        public string CanPostInClosedPeriod { get; set; } 
        [ConfigParam(name: "NumberOfDaysToPostBack", description: "Number of days user is allowed to post in closed periods", paramType:"int")]
        public string NumberOfDaysToPostBack { get; set; }
        [ConfigParam(name: "UseJournals", description: "Check whether journals are used", paramType:"bool")]
        public string UseJournals { get; set; }
        [ConfigParam(name: "UseVouchers", description: "Check whether vouchers are used", paramType:"bool")]
        public string UseVouchers { get; set; }
        [ConfigParam(name: "AllowUserDefinedVoucherNumbers", description: "Check whether users can enter voucher numbers", paramType:"bool")]
        public string AllowUserDefinedVoucherNumbers { get; set; }
        [ConfigParam(name: "PostSavingsVouchers", description: "Check whether savings transactions can be posted to vouchers", paramType:"bool")]
        public string PostSavingsVouchers { get; set; }
        [ConfigParam(name: "PostSavingsJournals", description: "Check whether savings transactions can be posted to journals", paramType:"bool")]
        public string PostSavingsJournals { get; set; }
        [ConfigParam(name: "PostRepaymentsToVouchers", description: "Check whether repayment transactions can be posted to vouchers", paramType:"bool")]
        public string PostRepaymentsToVouchers { get; set; }
        [ConfigParam(name: "PostRepaymentsToJournals", description: "Check whether repayment transactions can be posted to journals", paramType:"bool")]
        public string PostRepaymentsToJournals { get; set; }
        [ConfigParam(name: "DaysBack", description: "Number of days transactions can be posted in a closed period", paramType:"bool")]
        public string DaysBack { get; set; }
        [ConfigParam(name: "ModifyClosedTransactions", description: "Check whether modification of transactions in closed periods is allowed", paramType:"bool")]
        public string ModifyClosedTransactions { get; set; }
        [ConfigParam(name: "OpenDays", description: "Number of open days business can operate without day closures", paramType:"int")]
        public string OpenDays { get; set; }
        [ConfigParam(name: "UseAverageRate", description: "Check whether to use a stable exchange rate for Foreign transactions", paramType:"bool")]
        public string UseAverageRate { get; set; }
        [ConfigParam(name: "AllowMultiCurrency", description: "Check whether multi currency is enabled for General ledger posting", paramType:"bool")]
        public string AllowMultiCurrency { get; set; }
        [ConfigParam(name: "SoftDeleteLedgerTransactions", description: "Check whether mark objects as deleted instead of deleting them", paramType:"bool")]
        public string SoftDeleteLedgerTransactions { get; set; }
    }

}
