using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {

    public class TransactionParam {

        /// <summary>
        /// Check whether system is multi-branch
        /// </summary>
        public bool MultiBranch { get; set; }

        /// <summary>
        /// Get Or Set Financial year period eg.12 or 13 months
        /// </summary>
        public int YearPeriod { get; set; }=12;

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
        public string DefaultChart { get; set; }="US-UK";

        /// <summary>
        /// Type of chart of accounts used
        /// </summary>
        public ChartType ChartType { get; set; }

        /// <summary>
        /// Make approval of directly posted/manual posting entries mandatory
        /// </summary>
        public bool MustApproveDirectPosting { get; set; }=true;

        /// <summary>
        /// Check whether to include unapproved direct/manually posted unapproved transactions when closing day
        /// </summary>
        public bool IncludeUnapprovedTransactions { get; set; }=false;

        /// <summary>
        /// Check whether to automatically  print day's transaction report after closure
        /// </summary>
        public bool AutomaticallyPrintReportAfterClosure { get; set; }=true;

        /// <summary>
        /// User code for person authorized to approve directly posted entries
        /// </summary>
        public string AutomaticApprovalOfDirectPosting { get; set; }

        /// <summary>
        /// Make day closure mandatory
        /// </summary>
        public bool MustPerformDayClosure { get; set; }=true;

        /// <summary>
        /// Check whether users are allowed to post in closed periods
        /// </summary>
        public bool CanPostInClosedPeriod { get; set; }
        /// <summary>
        /// Get/Set the number of days user is allowed to post in closed periods
        /// </summary>
        public int NumberOfDaysToPostBack { get; set; }

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
        /// Check whether repayment transactions can be posted to vouchers
        /// </summary>
        public bool PostRepaymentsToVouchers { get; set; }

        /// <summary>
        /// Check whether repayment transactions can be posted to journals
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
        public bool AllowMultiCurrency { get; set; }

        /// <summary>
        /// Get Or Set whether mark objects as deleted instead of deleting them
        /// </summary>
        public bool SoftDeleteLedgerTransactions { get; set; } = true;
    }
}
