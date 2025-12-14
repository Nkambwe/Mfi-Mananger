using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class AccountingParameters : IConfigurationParameter {

        /// <summary>
        /// Check whether system is multi-branch
        /// </summary>
        public bool MultiBranch { get; set; }

        /// <summary>
        /// Branch transaction code id
        /// </summary>
        public string TransactionCode { get; set; }
        /// <summary>
        /// Branch ledger code id
        /// </summary>
        public string LedgerCode { get; set; }

        /// <summary>
        /// Get Or Set Financial year period eg.12 or 13 months
        /// </summary>
        public int YearPeriod { get; set; }

        /// <summary>
        /// First month of financial year
        /// </summary>
        public string YearStarts { get; set; }

        /// <summary>
        /// Last month of financial year
        /// </summary>
        public string YearEnds { get; set; }
        /// <summary>
        /// Default chart of accounts
        /// </summary>
        public string DefaultChart { get; set; }

        /// <summary>
        /// Type of chart of accounts
        /// </summary>
        public ChartType ChartType { get; set; }

        /// <summary>
        /// Make approval of directly posted entries mandatory
        /// </summary>
        public bool ApproveDirectPosting { get; set; }

        /// <summary>
        /// Check whether to include unapproved direct posted transactions when closing day
        /// </summary>
        public bool IncludeUnapprovedTransactions { get; set; }

        /// <summary>
        /// Check whether to print day's transaction report after closure
        /// </summary>
        public bool PrintReportAfterClosure { get; set; }

        /// <summary>
        /// User code for person authorized to approve directly posted entries
        /// </summary>
        public string AuthorizedApproval { get; set; }

        /// <summary>
        /// Make day closure mandatory
        /// </summary>
        public bool RequireClosure { get; set; }

        /// <summary>
        /// Check whether users are allowed to post in closed periods
        /// </summary>
        public bool CanPostInClosedPeriod { get; set; }

        /// <summary>
        /// Check whether journals are used
        /// </summary>
        public bool UseJournals { get; set; }

        /// <summary>
        /// Check whether vouchers are used
        /// </summary>
        public bool UseVouchers { get; set; }

        /// <summary>
        /// Check whether users can enter voucher numbers
        /// </summary>
        public bool AllowUserDefinedVoucherNumbers { get; set; }

        /// <summary>
        /// Check whether savings transactions can be posted to vouchers
        /// </summary>
        public bool PostSavingsVouchers { get; set; }

        /// <summary>
        /// Check whether savings transactions can be posted to journals
        /// </summary>
        public bool PostSavingsJournals { get; set; }

        /// <summary>
        /// Check whether savings transactions can be posted to vouchers
        /// </summary>
        public bool PostRepaymentsToVouchers { get; set; }

        /// <summary>
        /// Check whether savings transactions can be posted to journals
        /// </summary>
        public bool PostRepaymentsToJournals { get; set; }

        /// <summary>
        /// Number of days transactions can be posted in a closed period
        /// </summary>
        public int DaysBack { get; set; }

        /// <summary>
        /// Check whether modification of transactions in closed periods is allowed
        /// </summary>
        public bool ModifyClosedTransactions { get; set; }

        /// <summary>
        /// Number of open days business can operate without day closures
        /// </summary>
        public int OpenDays { get; set; }

        /// <summary>
        /// Get Or Set whether to use a stable exchange rate for Foreign transactions
        /// </summary>
        public bool UseAverageRate { get; set; }

        /// <summary>
        /// Check whether multi currency is enabled for General ledger posting
        /// </summary>
        public bool MultiCurrency { get; set; }

        /// <summary>
        /// Get Or Set whether mark objects as deleted instead of deleting them
        /// </summary>
        public bool MarkAsDeleted { get; set; } = true;
    }
}
