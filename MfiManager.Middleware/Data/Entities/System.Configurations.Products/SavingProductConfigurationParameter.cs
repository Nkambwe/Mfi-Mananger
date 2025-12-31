using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class SavingProductConfigurationParameter: IConfigurationParameter {
        [ConfigParam(name: "InterestBasedProduct", description: "Check whether product allows offering interest on savings balance", paramType: "bool")]
        public string InterestBasedProduct { get; set; }
        [ConfigParam(name: "InterestRate", description: "Savings interest rate", paramType: "decimal")]
        public string InterestRate { get; set; }
        [ConfigParam(name: "InterestDays", description: "Number of savings interest earning days in a year", paramType: "int")]
        public string InterestDays { get; set; }
        [ConfigParam(name: "InterestWeeks", description: "Number of savings interest earning weeks in a year", paramType: "int")]
        public string InterestWeeks { get; set; }
        [ConfigParam(name: "InterestMethod", description: "Savings interest calculation method", paramType: "int")]
        public string InterestMethod { get; set; }
        [ConfigParam(name: "OfferInterestOnDormantAccounts", description: "Check whether dormant accounts earn interest on their deposits", paramType: "bool")]
        public string OfferInterestOnDormantAccounts { get; set; }
        [ConfigParam(name: "LastRewardBonusCalculationDate", description: "Last datetime for calculation of rewards and bonuses", paramType: "datetime")]
        public string LastRewardBonusCalculationDate { get; set; }
        [ConfigParam(name: "ChargeWithholdingTaxOnSavingInterest", description: "Check whether product charges withholding tax on interest earned", paramType: "bool")]
        public string ChargeWithholdingTaxOnSavingInterest { get; set; }
        [ConfigParam(name: "LedgerForWithholdingTax", description: "Ledger account for Withholding Tax", paramType: "string")]
        public string LedgerForWithholdingTax { get; set; }
        [ConfigParam(name: "HasChequeBook", description: "Check whether product uses cheque books", paramType: "bool")]
        public string HasChequeBook { get; set; }
        [ConfigParam(name: "ChargePerLeaf", description: "Check whether cheque book is charged per leaf", paramType: "int")]
        public string ChargePerLeaf { get; set; }
        [ConfigParam(name: "ChequeBookCharge", description: "Cheque book amount charged. If ChargePerLeaf is true, the amount is per leaf", paramType: "decimal")]
        public string ChequeBookCharge { get; set; }
        [ConfigParam(name: "LedgerForChequeBookSales", description: "Ledger account to hold sales for cheque books", paramType: "string")]
        public string LedgerForChequeBookSales { get; set; }
        [ConfigParam(name: "AllowChequeDeposit", description: "Check whether product allows for cheque deposits", paramType: "bool")]
        public string AllowChequeDeposit { get; set; }
        [ConfigParam(name: "ChargeCommissionOnCheques", description: "Check whether to charge commission on cheques", paramType: "bool")]
        public string ChargeCommissionOnCheques { get; set; }
        [ConfigParam(name: "LedgerForInterBranchSavingsTransfer", description: "Ledger account for inter-branch saving transfer", paramType: "string")]
        public string LedgerForInterBranchSavingsTransfer { get; set; }
        [ConfigParam(name: "LedgerForInterBranchChequeClearing", description: "Ledger account for inter-branch cheque clearance", paramType: "string")]
        public string LedgerForInterBranchChequeClearing { get; set; }
        [ConfigParam(name: "TurnOnOverdraftProtection", description: "Check whether product allows overdraft protection", paramType: "bool")]
        public string TurnOnOverdraftProtection { get; set; }
        [ConfigParam(name: "OverdraftPeriod", description: "Overdraft period in days", paramType: "int")]
        public string OverdraftPeriod { get; set; }
        [ConfigParam(name: "OverdraftInterestRate", description: "Overdraft loan interest", paramType: "decimal")]
        public string OverdraftInterestRate { get; set; }
        [ConfigParam(name: "ChargeCommissionOnOverdraft", description: "Check whether product charges commission on overdraft", paramType: "bool")]
        public string ChargeCommissionOnOverdraft { get; set; }
        [ConfigParam(name: "LedgerForOverdraftInterestIndividualAccounts", description: "Ledger account for overdraft interest for individual accounts", paramType: "string")]
        public string LedgerForOverdraftInterestIndividualAccounts { get; set; }
        [ConfigParam(name: "LedgerForExpiredOverdraftInterestIndividualAccounts", description: "Ledger account for expired overdraft interest for individual accounts", paramType: "string")]
        public string LedgerForExpiredOverdraftInterestIndividualAccounts { get; set; }
        [ConfigParam(name: "LedgerForExpiredOverdraftInterestGroupAccounts", description: "Ledger account for overdraft interest for group accounts", paramType: "string")]
        public string LedgerForExpiredOverdraftInterestGroupAccounts { get; set; }
        [ConfigParam(name: "LedgerForOverdraftInterestBusinessAccounts", description: "Ledger account for overdraft interest for business accounts", paramType: "string")]
        public string LedgerForOverdraftInterestBusinessAccounts { get; set; }
        [ConfigParam(name: "LedgerForExpiredOverdraftInterestBusinessAccounts", description: "Ledger account for expired overdraft interest for business accounts", paramType: "string")]
        public string LedgerForExpiredOverdraftInterestBusinessAccounts { get; set; }
        [ConfigParam(name: "ChargeInterestOnNegativeBalances", description: "Check whether product charges interest on negative balances", paramType: "bool")]
        public string ChargeInterestOnNegativeBalances { get; set; }
        [ConfigParam(name: "NegativeBalanceInterestRate", description: "Percentage rate of interest charged on accounts with negative balances", paramType: "decimal")]
        public string NegativeBalanceInterestRate { get; set; }
        [ConfigParam(name: "MinimumInterestOnNegativeBalance", description: "Minimum interest charged on accounts with negative balances", paramType: "decimal")]
        public string MinimumInterestOnNegativeBalance { get; set; }
        [ConfigParam(name: "LedgerForNegativeBalanceInterestIndividualAccounts", description: "Ledger account for negative balance interest on individual accounts", paramType: "string")]
        public string LedgerForNegativeBalanceInterestIndividualAccounts { get; set; }
        [ConfigParam(name: "LedgerForNegativeBalanceInterestGroupAccounts", description: "Ledger account for negative balance interest on group accounts", paramType: "string")]
        public string LedgerForNegativeBalanceInterestGroupAccounts { get; set; }
        [ConfigParam(name: "LedgerForNegativeBalanceInterestBusinessAccounts", description: "Ledger account for negative balance interest on business accounts", paramType: "string")]
        public string LedgerForNegativeBalanceInterestBusinessAccounts { get; set; }
        [ConfigParam(name: "AutoExecuteStandingOrdersAtStartOfDay", description: "Check whether system automatically executes standing orders at start of day", paramType: "bool")]
        public string AutoExecuteStandingOrdersAtStartOfDay { get; set; }
        [ConfigParam(name: "ChargeInvocationFee", description: "Check whether product charges invocation fees on standing orders", paramType: "bool")]
        public string ChargeInvocationFee { get; set; }
        [ConfigParam(name: "ChargeOrderExecutionFee", description: "Check whether product charges execution fees on standing orders", paramType: "bool")]
        public string ChargeOrderExecutionFee { get; set; }
        [ConfigParam(name: "ChargeStandingOrderAmendmentFee", description: "Check whether product charges amendment fees on standing orders", paramType: "bool")]
        public string ChargeStandingOrderAmendmentFee { get; set; }
        [ConfigParam(name: "ChargePenaltyStandingOrder", description: "Check whether product imposes penalty on standing orders", paramType: "bool")]
        public string ChargePenaltyStandingOrder { get; set; }
        [ConfigParam(name: "LedgerForStandingOrderHolding", description: "Ledger account for Holding Standing orders", paramType: "string")]
        public string LedgerForStandingOrderHolding { get; set; }
        [ConfigParam(name: "EnableSmsLedgerForStandingOrderTransactionsBanking", description: "Ledger account for standing order transactions", paramType: "string")]
        public string LedgerForStandingOrderTransactions { get; set; }
        [ConfigParam(name: "EnableSmsBanking", description: "Check whether product allows for SMS banking", paramType: "bool")]
        public string EnableSmsBanking { get; set; }
        [ConfigParam(name: "MaximumAmountPerSmsTransaction", description: "Maximum amount chargeable per SMS transaction", paramType: "decimal")]
        public string MaximumAmountPerSmsTransaction { get; set; }
        [ConfigParam(name: "EnableElectronicCardTransaction", description: "Check whether product allows for Electronic Card transactions", paramType: "bool")]
        public string EnableElectronicCardTransaction { get; set; }
        [ConfigParam(name: "ElectronicCardNumberLength", description: "Length of Visa Card Number", paramType: "int")]
        public string ElectronicCardNumberLength { get; set; }
        [ConfigParam(name: "ElectronicCardValidityInYears", description: "Validity of card number", paramType: "int")]
        public string ElectronicCardValidityInYears { get; set; }
        [ConfigParam(name: "ChargeExerciseDutyOnElectronicCards", description: "Check whether product charges exercise duty on visa cards", paramType: "bool")]
        public string ChargeExerciseDutyOnElectronicCards { get; set; }
        [ConfigParam(name: "LedgerForExerciseDutyTax", description: "Ledger for exercise duty Tax", paramType: "string")]
        public string LedgerForExerciseDutyTax { get; set; }
        [ConfigParam(name: "ElectronicCardWithdrawLimit", description: "Maximum amount that a person can withdraw with an electronic card", paramType: "decimal")]
        public string ElectronicCardWithdrawLimit { get; set; }
        [ConfigParam(name: "ElectronicCardPurchaseLimit", description: "Maximum unit amount that a person can purchase with an electronic card", paramType: "decimal")]
        public string ElectronicCardPurchaseLimit { get; set; }
        [ConfigParam(name: "LedgerForOtherTax", description: "Check whether product charges withdraw commission", paramType: "string")]
        public string LedgerForOtherTax { get; set; }
        [ConfigParam(name: "ChargeWithdrawCommission", description: "Check whether product charges withdraw commission", paramType: "bool")]
        public string ChargeWithdrawCommission { get; set; }
        [ConfigParam(name: "UseWithdrawCommissionRages", description: "Check whether product charges withdraw commission with in range of withdraw amounts [See withdraw commission ranges]", paramType: "bool")]
        public string UseWithdrawCommissionRages { get; set; }
        [ConfigParam(name: "WithdrawInterval", description: "Official allowed number of days between two withdraws. With attracts a penalty", paramType: "int")]
        public string WithdrawInterval { get; set; }
        [ConfigParam(name: "ChargePenaltyForWithdrawInterval", description: "Check whether product charges withdraw penalty if withdraw make before official interval between withdraws", paramType: "bool")]
        public string ChargePenaltyForWithdrawInterval { get; set; }
        [ConfigParam(name: "ChargeStationeryFees", description: "Check whether product charges stationery fees", paramType: "bool")]
        public string ChargeStationeryFees { get; set; }
        [ConfigParam(name: "MinimumClientAge", description: "Minimum age of customers fr this product", paramType: "int")]
        public string MinimumClientAge { get; set; }
        [ConfigParam(name: "AllowMultiCurrency", description: "Check whether product allows multiple currency transactions", paramType: "bool")]
        public string AllowMultiCurrency { get; set; }
        [ConfigParam(name: "ShowCurrencyNotesOnDepositSlips", description: "Check whether currency denominations are displayed on deposit slips", paramType: "bool")]
        public string ShowCurrencyNotesOnDepositSlips { get; set; }
        [ConfigParam(name: "ShowCurrencyNotesOnWithdrawSlips", description: "Check whether currency denominations are displayed on withdraw slips", paramType: "bool")]
        public string ShowCurrencyNotesOnWithdrawSlips { get; set; }
        [ConfigParam(name: "UseWithdrawCommissionRange", description: "Check whether to use commission rages at withdraw", paramType: "bool")]
        public string UseWithdrawCommissionRange { get; set; }
        [ConfigParam(name: "ChargeSavingsTransferFees", description: "Check whether product charges savings transfer fees", paramType: "bool")]
        public string ChargeSavingsTransferFees { get; set; }
        [ConfigParam(name: "RequireApprovalForWithdraws", description: "Check whether product requires supervisor approvals for withdraws", paramType: "bool")]
        public string RequireApprovalForWithdraws { get; set; }
        [ConfigParam(name: "ConsiderDormantAfterDaysOfInactivity", description: "Number of days an account is active for it to be considered dormant", paramType: "int")]
        public string ConsiderDormantAfterDaysOfInactivity { get; set; }
        [ConfigParam(name: "TrackDormantGroupAccountsPerMember", description: "Check whether product requires tracking dormant group accounts per member", paramType: "bool")]
        public string TrackDormantGroupAccountsPerMember { get; set; }
        [ConfigParam(name: "EnforceIndividualSaving", description: "Check whether individual savings are required", paramType: "bool")]
        public string EnforceIndividualSaving { get; set; }
        [ConfigParam(name: "LedgerForIndividualDeposits", description: "Ledger account for individual deposits", paramType: "string")]
        public string LedgerForIndividualDeposits { get; set; }
        [ConfigParam(name: "LedgerForInterestOnIndividualDeposits", description: "Ledger account for interest earned on individual deposits", paramType: "string")]
        public string LedgerForInterestOnIndividualDeposits { get; set; }
        [ConfigParam(name: "LedgerForAccruedInterestEarnedOnIndividualDeposits", description: "Ledger account for accrued interest earned on individual deposits", paramType: "string")]
        public string LedgerForAccruedInterestEarnedOnIndividualDeposits { get; set; }
        [ConfigParam(name: "LedgerForAccruedInterestEarnedCostOnIndividualDeposits", description: "Ledger account for accrued interest earned cost on individual deposits", paramType: "string")]
        public string LedgerForAccruedInterestEarnedCostOnIndividualDeposits { get; set; }
        [ConfigParam(name: "MinimumBalanceIndividualAccounts", description: "Minimum withdraw balance for individual saving accounts", paramType: "decimal")]
        public string MinimumBalanceIndividualAccounts { get; set; }
        [ConfigParam(name: "MinimumInterestEarningBalanceIndividualAccounts", description: "Minimum account balance that earns interest for individuals saving accounts", paramType: "decimal")]
        public string MinimumInterestEarningBalanceIndividualAccounts { get; set; }
        [ConfigParam(name: "MinimumBalanceJointAccounts", description: "Minimum withdraw balance for joint saving accounts", paramType: "decimal")]
        public string MinimumBalanceJointAccounts { get; set; }
        [ConfigParam(name: "MinimumInterestEarningBalanceJointAccounts", description: "Minimum account balance that earns interest for joint saving accounts", paramType: "decimal")]
        public string MinimumInterestEarningBalanceJointAccounts { get; set; }
        [ConfigParam(name: "EnforceGroupSaving", description: "Check whether group savings are required", paramType: "bool")]
        public string EnforceGroupSaving { get; set; }
        [ConfigParam(name: "LedgerForGroupsDeposits", description: "Ledger account for group deposits", paramType: "string")]
        public string LedgerForGroupsDeposits { get; set; }
        [ConfigParam(name: "LedgerForInterestOnGroupsDeposits", description: "Ledger account for interest earned on group deposits", paramType: "string")]
        public string LedgerForInterestOnGroupsDeposits { get; set; }
        [ConfigParam(name: "LedgerForAccruedInterestEarnedOnGroupDeposits", description: "Ledger account for accrued interest earned on group deposits", paramType: "string")]
        public string LedgerForAccruedInterestEarnedOnGroupDeposits { get; set; }
        [ConfigParam(name: "LedgerForAccruedInterestEarnedCostOnGroupDeposits", description: "Ledger account for accrued interest earned cost on group deposits", paramType: "string")]
        public string LedgerForAccruedInterestEarnedCostOnGroupDeposits { get; set; }
        [ConfigParam(name: "BreakGroupAccountsToIndividualMemberAccounts", description: "Check whether group accounts are broken down per member", paramType: "bool")]
        public string BreakGroupAccountsToIndividualMemberAccounts { get; set; }
        [ConfigParam(name: "MinimumBalanceGroupAccounts", description: "Minimum withdraw balance for group saving accounts", paramType: "decimal")]
        public string MinimumBalanceGroupAccounts { get; set; }
        [ConfigParam(name: "MinimumInterestEarningBalanceGroupAccounts", description: "Minimum account balance that earns interest for group saving accounts", paramType: "decimal")]
        public string MinimumInterestEarningBalanceGroupAccounts { get; set; }
        [ConfigParam(name: "EnforceBusinessSaving", description: "Check whether business savings are required", paramType: "bool")]
        public string EnforceBusinessSaving { get; set; }
        [ConfigParam(name: "LedgerForBusinessDeposits", description: "Ledger account for business deposits", paramType: "string")]
        public string LedgerForBusinessDeposits { get; set; }
        [ConfigParam(name: "LedgerForInterestOnBusinessDeposits", description: "Ledger account for interest earned on business deposits", paramType: "string")]
        public string LedgerForInterestOnBusinessDeposits { get; set; }
        [ConfigParam(name: "LedgerForAccruedInterestEarnedOnBusinessDeposits", description: "Ledger account for accrued interest earned on business deposits", paramType: "string")]
        public string LedgerForAccruedInterestEarnedOnBusinessDeposits { get; set; }
        [ConfigParam(name: "LedgerForAccruedInterestEarnedCostOnBusinessDeposits", description: "Ledger account for accrued interest earned cost on business deposits", paramType: "string")]
        public string LedgerForAccruedInterestEarnedCostOnBusinessDeposits { get; set; }
        [ConfigParam(name: "MinimumBalanceBusinessAccounts", description: "Minimum withdraw balance for business saving accounts", paramType: "decimal")]
        public string MinimumBalanceBusinessAccounts { get; set; }
        [ConfigParam(name: "MinimumInterestEarningBalanceBusinessAccounts", description: "Minimum account balance that earns interest for business saving accounts", paramType: "decimal")]
        public string MinimumInterestEarningBalanceBusinessAccounts { get; set; }

    }

}
