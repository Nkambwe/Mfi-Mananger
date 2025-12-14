using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Products.Configurations {
    public class SavingProductConfiguration : IProductConfiguration {
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
        /// Get or Set value indicating whether product charges withdraw commission
        /// </summary>
        public bool ChargeWithdrawCommission { get; set; } = false;
        /// <summary>
        /// Get or Set value indicating whether product charges withdraw commission with in range of withdraw amounts [See withdraw commission ranges]
        /// </summary>
        public bool UseWithdrawCommissionRages { get; set; } = false;
        /// <summary>
        /// Get Or Set the official allowed number of days between two withdraws. With attracts a penalty
        /// </summary>
        public int WithdrawInterval { get; set; } = 0;
        /// <summary>
        /// Get or Set value indicating whether product charges withdraw penalty if withdraw make before official interval between withdraws
        /// </summary>
        public bool ChargePenaltyForWithdrawInterval { get; set; } = false;
        /// <summary>
        /// Get or Set value indicating whether product charges stationery fees
        /// </summary>
        public bool ChargeStationeryFees { get; set; } = false;
        /// <summary>
        /// Get Or Set required client minimum age for this product
        /// </summary>
        public int MinimumClientAge { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product allows multiple currency transactions
        /// </summary>
        public bool AllowMultiCurrency { get; set; }
        /// <summary>
        /// Get or Set value indicating whether currency denominations are displayed on deposit slips
        /// </summary>
        public bool ShowCurrencyNotesOnDepositSlips { get; set; } = false;
        /// <summary>
        /// Get or Set value indicating whether currency denominations are displayed on withdraw slips
        /// </summary>
        public bool ShowCurrencyNotesOnWithdrawSlips { get; set; } = false;
        /// <summary>
        /// Get Or Set value indicating whether to use commission rages at withdraw
        /// </summary>
        public bool UseWithdrawCommissionRange { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product charges savings transfer fees
        /// </summary>
        public bool ChargeSavingsTransferFees { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product requires supervisor approvals for withdraws
        /// </summary>
        public bool RequireApprovalForWithdraws { get; set; } = false;
        /// <summary>
        /// Get or Set value indicating whether product requires supervisor approvals for withdraws above cashier limit
        /// </summary>
        public bool RequireApprovalForWithdrawsAboveCashierLimit { get; set; } = false;
        /// <summary>
        /// Get or Set list of authorities that can approve withdraws above cashier limit
        /// </summary>
        public List<string> AuthoritiesToWithdrawAboveCashierLimit { get; set; } = new List<string> { "Manager", "Supervisor" };
        /// <summary>
        /// Get or Set value indicating whether transactions are to be displayed starting with latest
        /// </summary>
        public bool DisplayChronologically { get; set; } = false;
        /// <summary>
        /// Get or Set number of days an account is active for it to be considered dormant
        /// </summary>
        public int ConsiderDormantAfterDaysOfInactivity { get; set; } = 365;
        /// <summary>
        ///  Get or Set value indicating whether product requires tracking dormant group accounts per member
        /// </summary>
        public bool TrackDormantGroupAccountsPerMember { get; set; } = false;
        /// <summary>
        ///  Get or Set value indicating whether product requires supervisor approval to activate dormant accounts
        /// </summary>
        public bool RequireSupervisorApprovalToActivateDormantAccounts { get; set; } = false;
        /// <summary>
        /// Get or Set list of authorities that can approve activation of dormant accounts
        /// </summary>
        public List<string> AuthoritiesToActivateOfDormantAccounts { get; set; } = new List<string> { "Manager", "Supervisor" };
        /// <summary>
        /// Get or Set value indicating whether individual savings are required
        /// </summary>
        public bool EnforceIndividualSaving { get; set; } = false;
        /// <summary>
        /// Get or Set ledger account for individual deposits
        /// </summary>
        public string LedgerForIndividualDeposits { get; set; } = "210201";
        /// <summary>
        /// Get or Set ledger account for interest earned on individual deposits
        /// </summary>
        public string LedgerForInterestOnIndividualDeposits { get; set; } = "510010";
        /// <summary>
        /// Get or Set ledger account for accrued interest earned on individual deposits
        /// </summary>
        public string LedgerForAccruedInterestEarnedOnIndividualDeposits { get; set; } = "240010";
        /// <summary>
        /// Get or Set ledger account for accrued interest earned cost on individual deposits
        /// </summary>
        public string LedgerForAccruedInterestEarnedCostOnIndividualDeposits { get; set; } = "511010";
        /// <summary>
        /// Get or set minimum withdraw balance for individual saving accounts
        /// </summary>
        public decimal MinimumBalanceIndividualAccounts { get; set; }
        /// <summary>
        /// Get or set minimum account balance that earns interest for individuals saving accounts
        /// </summary>
        public decimal MinimumInterestEarningBalanceIndividualAccounts { get; set; }
        /// <summary>
        /// Get or set minimum withdraw balance for joint saving accounts
        /// </summary>
        public decimal MinimumBalanceJointAccounts { get; set; }
        /// <summary>
        /// Get or set minimum account balance that earns interest for joint saving accounts
        /// </summary>
        public decimal MinimumInterestEarningBalanceJointAccounts { get; set; }
        /// <summary>
        /// Get or Set value indicating whether group savings are required
        /// </summary>
        public bool EnforceGroupSaving { get; set; } = false;
        /// <summary>
        /// Get or Set ledger account for groups deposits
        /// </summary>
        public string LedgerForGroupsDeposits { get; set; } = "210202";
        /// <summary>
        /// Get or Set ledger account for interest on groups deposits
        /// </summary>
        public string LedgerForInterestOnGroupsDeposits { get; set; } = "510020";
        /// <summary>
        /// Get or Set ledger account for accrued interest earned on groups deposits
        /// </summary>
        public string LedgerForAccruedInterestEarnedOnGroupDeposits { get; set; } = "240020";
        /// <summary>
        /// Get or Set ledger account for accrued interest earned cost on groups deposits
        /// </summary>
        public string LedgerForAccruedInterestEarnedCostOnGroupDeposits { get; set; } = "511020";
        /// <summary>
        /// Get or Set value indicating whether group accounts are broken down per member
        /// </summary>
        public bool BreakGroupAccountsToIndividualMemberAccounts { get; set; } = false;
        /// <summary>
        /// Get or set minimum withdraw balance for group saving accounts
        /// </summary>
        public decimal MinimumBalanceGroupAccounts { get; set; }
        /// <summary>
        /// Get or set minimum account balance that earns interest for group saving accounts
        /// </summary>
        public decimal MinimumInterestEarningBalanceGroupAccounts { get; set; }
        /// <summary>
        /// Get or Set value indicating whether business savings are required
        /// </summary>
        public bool EnforceBusinessSaving { get; set; } = false;
        /// <summary>
        /// Get or Set ledger account for business deposits
        /// </summary>
        public string LedgerForBusinessDeposits { get; set; } = "210203";
        /// <summary>
        /// Get or Set ledger account for interest on business deposits
        /// </summary>
        public string LedgerForInterestOnBusinessDeposits { get; set; } = "510030";
        /// <summary>
        /// Get or Set ledger account for accrued interest earned on business deposits
        /// </summary>
        public string LedgerForAccruedInterestEarnedOnBusinessDeposits { get; set; } = "240030";
        /// <summary>
        /// Get or Set ledger account for accrued interest earned cost on business deposits
        /// </summary>
        public string LedgerForAccruedInterestEarnedCostOnBusinessDeposits { get; set; } = "511030";
        /// <summary>
        /// Get or set minimum withdraw balance for business saving accounts
        /// </summary>
        public decimal MinimumBalanceBusinessAccounts { get; set; }
        /// <summary>
        /// Get or set minimum account balance that earns interest for businesses saving accounts
        /// </summary>
        public decimal MinimumInterestEarningBalanceBusinessAccounts { get; set; }
        /// <summary>
        /// Get or Set value indicating whether savings transactions are also booked to the general ledger
        /// </summary>
        public bool BookSavingsToGeneralLedger { get; set; } = true;
        /// <summary>
        /// Get or Set value indicating whether product allows offering interest on savings balance
        /// </summary>
        public bool InterestBasedProduct { get; set; }
        /// <summary>
        /// Get or Set savings interest rate
        /// </summary>
        public decimal InterestRate { get; set; } = 0.00M;
        /// <summary>
        /// Get or Set number of savings interest earning days in a year
        /// </summary>
        public int InterestDays { get; set; } = 365;
        /// <summary>
        ///Get or Set number of savings interest earning weeks in a year
        /// </summary>
        public int InterestWeeks { get; set; } = 52;
        /// <summary>
        /// Get or Set savings interest calculation method
        /// </summary>
        public SavingInterestCalculation InterestMethod { get; set; }
        /// <summary>
        /// Get or Set value indicating whether dormant accounts earn interest on their deposits
        /// </summary>
        public bool OfferInterestOnDormantAccounts { get; set; } = false;
        /// <summary>
        ///Get or Set last date savings interest was calculated
        /// </summary>
        public DateTime? LastInterestCalculationDate { get; set; } = null;
        /// <summary>
        /// Get Or Set the last date for calculation of rewards and bonuses
        /// </summary>
        public DateTime? LastRewardBonusCalculationDate { get; set; } = null;
        /// <summary>
        ///  Get or Set value indicating whether product charges withholding tax on interest earned
        /// </summary>
        public bool ChargeWithholdingTaxOnSavingInterest { get; set; } = false;
        /// <summary>
        /// Get Or Set withholding tax code attached to this product [See Withholding tax]
        /// </summary>
        public string WithholdingTaxCode { get; set; } = "WHTAX04";
        /// <summary>
        /// Get Or Set ledger for Withholding Tax
        /// </summary>
        public string LedgerForWithholdingTax { get; set; } = "";
        /// <summary>
        /// Get or Set value indicating whether product uses cheque books
        /// </summary>
        public bool HasChequeBook { get; set; } = false;
        /// <summary>
        /// Get or Set number of leaves in a cheque book
        /// </summary>
        public int NumberOfLeafs { get; set; } = 0;
        /// <summary>
        /// Get or Set value indicating whether cheque book is charged per leaf
        /// </summary>
        public bool ChargePerLeaf { get; set; } = false;
        /// <summary>
        /// Get Or Set cheque book amount charged. If ChargePerLeaf is true, the amount is per leaf
        /// </summary>
        public decimal ChequeBookCharge { get; set; } = 0.00M;
        /// <summary>
        /// Get Or Set ledger account to hold sales for cheque books
        /// </summary>
        public string LedgerForChequeBookSales { get; set; } = "";
        /// <summary>
        ///  Get or Set value indicating whether product allows for cheque deposits
        /// </summary>
        public bool AllowChequeDeposit { get; set; } = false;
        /// <summary>
        /// Get Or Set cheque commissions
        /// </summary>
        public bool ChargeCommissionOnCheques { get; set; } = false;
        /// <summary>
        /// Get Or Set ledger account for inter-branch saving transfer
        /// </summary>
        public string LedgerForInterBranchSavingsTransfer { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for inter-branch cheque clearance
        /// </summary>
        public string LedgerForInterBranchChequeClearing { get; set; } = "";
        /// <summary>
        /// Get Or Set value indicating whether product allows overdraft protection
        /// </summary>
        public bool TurnOnOverdraftProtection { get; set; } = true;
        /// <summary>
        /// Get Or Set overdraft period in days
        /// </summary>
        public int OverdraftPeriod { get; set; } = 30;
        /// <summary>
        /// Get Or Set overdraft loan interest
        /// </summary>
        public decimal OverdraftInterestRate { get; set; } = 0;
        /// <summary>
        /// Get Or Set value indicating whether product charges commission on overdraft
        /// </summary>
        public bool ChargeCommissionOnOverdraft { get; set; }
        /// <summary>
        /// Get Or Set ledger account for overdraft interest for individual accounts
        /// </summary>
        public string LedgerForOverdraftInterestIndividualAccounts { get; set; }
        /// <summary>
        /// Get Or Set ledger account for expired overdraft interest for individual accounts
        /// </summary>
        public string LedgerForExpiredOverdraftInterestIndividualAccounts { get; set; } = "440121";
        /// <summary>
        /// Get Or Set ledger account for overdraft interest for group accounts
        /// </summary>
        public string LedgerForOverdraftInterestGroupAccounts { get; set; }
        /// <summary>
        /// Get Or Set ledger account for expired overdraft interest for group accounts
        /// </summary>
        public string LedgerForExpiredOverdraftInterestGroupAccounts { get; set; } = "440122";
        /// <summary>
        /// Get Or Set ledger account for overdraft interest for business accounts
        /// </summary>
        public string LedgerForOverdraftInterestBusinessAccounts { get; set; }
        /// <summary>
        /// Get Or Set ledger account for expired overdraft interest for business accounts
        /// </summary>
        public string LedgerForExpiredOverdraftInterestBusinessAccounts { get; set; } = "440123";
        /// <summary>
        /// Get Or Set value indicating whether product charges interest on negative balances
        /// </summary>
        public bool ChargeInterestOnNegativeBalances { get; set; }
        /// <summary>
        /// Get Or Set rate of interest charged on accounts with negative balances
        /// </summary>
        public decimal NegativeBalanceInterestRate { get; set; } = 0.00M;
        /// <summary>
        /// Get Or Set minimum interest charged on accounts with negative balances
        /// </summary>
        public decimal MinimumInterestOnNegativeBalance { get; set; } = 0.00M;
        /// <summary>
        /// Get Or Set ledger account for negative balance interest on individual accounts
        /// </summary>
        public string LedgerForNegativeBalanceInterestIndividualAccounts { get; set; } = "440111";
        /// <summary>
        /// Get Or Set ledger account for negative balance interest on group accounts
        /// </summary>
        public string LedgerForNegativeBalanceInterestGroupAccounts { get; set; } = "440112";
        /// <summary>
        /// Get Or Set ledger account for negative balance interest on business accounts
        /// </summary>
        public string LedgerForNegativeBalanceInterestBusinessAccounts { get; set; } = "440113";
        /// <summary>
        /// Get Or Set value indicating whether system automatically executes standing orders at start of day
        /// </summary>
        public bool AutoExecuteStandingOrdersAtStartOfDay { get; set; } = false;
        /// <summary>
        /// Get Or Set value indicating whether product charges invocation fees on standing orders
        /// </summary>
        public bool ChargeInvocationFee { get; set; } = false;
        /// <summary>
        /// Get Or Set value indicating whether product charges execution fees on standing orders
        /// </summary>
        public bool ChargeOrderExecutionFee { get; set; } = false;
        /// <summary>
        /// Get Or Set value indicating whether product charges amendment fees on standing orders
        /// </summary>
        public bool ChargeStandingOrderAmendmentFee { get; set; } = false;
        /// <summary>
        /// Get Or Set value indicating whether product imposes penalty on standing orders
        /// </summary>
        public bool ChargePenaltyStandingOrder { get; set; } = false;
        /// <summary>
        /// Get Or Set ledger account for Holding Standing orders
        /// </summary>
        public string LedgerForStandingOrderHolding { get; set; } = "440116";
        /// <summary>
        /// Get Or Set ledger account for standing order transactions
        /// </summary>
        public string LedgerForStandingOrderTransactions { get; set; } = "";
        /// <summary>
        /// Get Or Set value indicating whether product allows for SMS banking
        /// </summary>
        public bool EnableSmsBanking { get; set; } = false;
        /// <summary>
        /// Get Or Set maximum amount chargeable per SMS transaction
        /// </summary>
        public decimal MaximumAmountPerSmsTransaction { get; set; } = 0.00M;
        /// <summary>
        /// Get Or Set value indicating whether product allows for Electronic Card transactions
        /// </summary>
        public bool EnableElectronicCardTransaction { get; set; } = false;
        /// <summary>
        /// Get Or Set length of Visa Card Number
        /// </summary>
        public int ElectronicCardNumberLength { get; set; } = 10;
        /// <summary>
        /// Get Or Set validity of card number
        /// </summary>
        public int ElectronicCardValidityInYears { get; set; } = 0;
        /// <summary>
        /// Get or Set value indicating whether product charges exercise duty on visa cards
        /// </summary>
        public bool ChargeExerciseDutyOnElectronicCards { get; set; } = false;
        /// <summary>
        /// Get Or Set exercise duty tax code attached to this product 
        /// </summary>
        public string ExerciseDutyTaxCode { get; set; } = "EXETAX01";
        /// <summary>
        /// Get Or Set ledger for exercise duty Tax
        /// </summary>
        public string LedgerForExerciseDutyTax { get; set; } = "";
        /// <summary>
        /// Get Or Set maximum amount that a person can withdraw with an electronic card
        /// </summary>
        public decimal ElectronicCardWithdrawLimit { get; set; } = 0;
        /// <summary>
        /// Get Or Set maximum unit amount that a person can purchase with an electronic card
        /// </summary>
        public decimal ElectronicCardPurchaseLimit { get; set; } = 0;
        /// <summary>
        /// Get Or Set ledger account for other taxes
        /// </summary>
        public string LedgerForTax { get; set; } = "";

        /// <summary>
        /// Get Or Set default posting voucher
        /// </summary>
        public string VoucherCode { get; set; } = "";

        /// <summary>
        /// Get Or Set default journal voucher
        /// </summary>
        public string JournalCode { get; set; } = "";
    }
}
