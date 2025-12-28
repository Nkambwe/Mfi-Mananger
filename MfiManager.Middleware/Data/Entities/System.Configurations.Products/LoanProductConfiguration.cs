using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {
    public class LoanProductConfiguration {
        /// <summary>
        ///  Get or Set value indicating whether product is only availed to saving clients
        /// </summary>
        public bool AvailableToSavingCustomersOnly { get; set; }
        /// <summary>
        /// Get Or Set product code for savings product attached to this loan product
        /// </summary>
        public string LinkedSavingsProduct { get; set; }
        /// <summary>
        /// Get Or Set the number of interest days in a year
        /// </summary>
        public int InterestDays { get; set; }
        /// <summary>
        /// Get Or Set the number of interest weeks in a year
        /// </summary>
        public int InterestWeeks { get; set; }
        /// <summary>
        ///  Get or Set the number of loan approval stages involved [see Approval stages]
        /// </summary>
        public TierApproval LoanApprovalStages { get; set; } = TierApproval.Tier1;
        /// <summary>
        /// Get or Set value indicating whether modification of due dates at disbursement must be enforced
        /// </summary>
        public bool ForceModificationOfDueDates { get; set; }
        /// <summary>
        /// Get or Set due dates modification method
        /// </summary>
        public LoanDueModificationMethod ModificationOMethod { get; set; } = LoanDueModificationMethod.None;
        /// <summary>
        ///  Get or Set value indicating whether product uses effective interest rate
        /// </summary>
        public bool UseEffectiveInterestRate { get; set; }
        /// <summary>
        /// Get or Set value indicating whether loan records should be mail merged
        /// </summary>
        public bool MailMergeRecords { get; set; }
        /// <summary>
        /// Get Or Set mail merge option
        /// </summary>
        public MailMergeRecord MailMerge { get; set; } = MailMergeRecord.Undefined;
        /// <summary>
        /// Get or Set value indicating whether loan interest must be recalculated at repayment
        /// </summary>
        public bool RecalculateInterest { get; set; }
        /// <summary>
        /// Get or Set value indicating whether loan interest is to be recalculated only if interest is not calculated in days
        /// </summary>
        public bool OnlyIfInterestNotCalculatedIndays { get; set; }
        /// <summary>
        /// Get Or Set interest recalculation method
        /// </summary>
        public InterestCalculation RecalculationMethod { get; set; } = InterestCalculation.Undefined;
        /// <summary>
        /// Get or Set value indicating whether unpaid interest should not be reset during reclaculation
        /// </summary>
        public bool NoResetInterest { get; set; }
        /// <summary>
        /// Get or Set value indicating whether interest is frozen for loans lin arrears after a certain number of days
        /// </summary>
        public bool FreezInterestWhenInArrears { get; set; }
        /// <summary>
        /// Get Or Set number of days that a loan must be in arrears for interest to be frozen
        /// </summary>
        public int DaysToConsiderInArrearsToFreezInterest { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to declassify interest in arrears
        /// </summary>
        public bool DeclassifyInterestInArrears { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to declassify principal in arrears
        /// </summary>
        public bool DeclassifyPrincipalInArrears { get; set; }
        /// <summary>
        /// Get or Set value indicating whether interest is compounded at repayment for loands with interest calculated with declininh balance method
        /// </summary>
        public bool CompoundInterestAtRepayment { get; set; }
        /// <summary>
        /// Get or Set value indicating whether maximum loan limit can be ignored when giving out loans
        /// </summary>
        public bool IgnoreMaximumLimit { get; set; }
        /// <summary>
        /// Get or Set value indicating whether partial disbursements are allowed
        /// </summary>
        public bool AllowPartialDisbursements { get; set; }
        /// <summary>
        /// Get or Set value indicating whether product sets loan payment priority
        /// </summary>
        public bool UseRepaymentPriority { get; set; }
        /// <summary>
        /// Get Or Set repayment priority order
        /// </summary>
        public RepaymentPriority RepaymentPriority { get; set; } = RepaymentPriority.Undefined;
        /// <summary>
        /// Get Or Set number of days that a loan must be in arrears for loans using repayment priority
        /// </summary>
        public int DaysToConsiderInArrearsForRepaymentPriorityLoans { get; set; }
        /// <summary>
        /// Get or Set value indicating whether loan considers the use of Duplum rule when calculating interest
        /// </summary>
        public bool UseDuplum { get; set; }
        /// <summary>
        /// Get or Set value indicating whether dues falling from on a certain day eg. 26-30 can be pushed to theend of month
        /// </summary>
        public bool PushDuesFromToMonthEnd { get; set; }
        /// <summary>
        /// Get or Set day of month from which all dues falling on that date upwards are pushed to the end of month
        /// </summary>
        public int PushDuesFrom { get; set; } = 26;

        /*taxes*/
        /// <summary>
        ///  Get or Set value indicating whether product charges witholding tax on professional fees
        /// </summary>
        public bool ChargeWitholdingTaxOnFees { get; set; } = false;
        /// <summary>
        /// Get Or Set witholding tax code attached to this product
        /// </summary>
        public string WitholdingTaxCode { get; set; } 
        /// <summary>
        /// Get Or Set ledger for Witholding Tax
        /// </summary>
        public string LedgerForWitholdingTax { get; set; } = "";
        /// <summary>
        ///  Get or Set value indicating whether product charges stamp duty product
        /// </summary>
        public bool ChargeStampDuty { get; set; } = false;
        /// <summary>
        /// Get Or Set stamp duty code for mortgage deeds attached to this product
        /// </summary>
        public string StampDutyOnMortgage { get; set; }
        /// <summary>
        /// Get Or Set stamp duty code for principal attached to this product
        /// </summary>
        public string StampDutyOnProncipal { get; set; }
        /// <summary>
        /// Get Or Set stamp duty code for interest attached to this product
        /// </summary>
        public string StampDutyOnInterest { get; set; }
        /// <summary>
        /// Get Or Set ledger for stamp duty on personal loans principal
        /// </summary>
        public string LedgerForStampDutyOnPrincipalPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on personal loans interest
        /// </summary>
        public string LedgerForStampDutyOnInterestPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on group loans principal
        /// </summary>
        public string LedgerForStampDutyOnPrincipalGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on group loans interest
        /// </summary>
        public string LedgerForStampDutyOnInterestGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on business loans principal
        /// </summary>
        public string LedgerForStampDutyOnPrincipalBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger for stamp duty on business loans interest
        /// </summary>
        public string LedgerForStampDutyOnInterestBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for other taxes
        /// </summary>
        public string LedgerForTax { get; set; } = "";
        /// <summary>
        /// Get Or Set ledgercard disclaimer text
        /// </summary>
        public string LedgerCardDisclaimer { get; set; } = "";

        /*individual loan*/
        /// <summary>
        /// Get Or Set minimum number of days for all individual loans of this product
        /// </summary>
        public int MinimumDaysAsClientPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set default loan amount for individual loan for this product
        /// </summary>
        public decimal LoanAmountForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default amount on all individual loans for this product
        /// </summary>
        public bool EnforceDefaultLoanAmountForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set the minimum loan amount offered for individual loans for this product
        /// </summary>
        public decimal MinimumLoanAmountForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set the maximum loan amount offered for individual loans for this product
        /// </summary>
        public decimal MaximumLoanAmountForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan amount offered must not exceed a given percentage of the individual's income
        /// individual loans for this product
        /// </summary>
        public bool CannotExceedIncomePercentage { get; set; }
        /// <summary>
        /// Get Or Set percentage of individual's income that loan amount cannot exceed for individual loans for this product
        /// </summary>
        public decimal IncomePercentage { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan cycles can exceed the standard cycles set for this product for individual loans for this product
        /// </summary>
        public bool CanIncreaseLoanCyclesForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan amount validation is done per cycle for individual loans for this product
        /// </summary>
        public bool TurnOnLoanAmountValidationPerCyclePersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set default interest rate for individual loan for this product
        /// </summary>
        public decimal DefaultInterestRateForPersonalLoan { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default interest rate on all individual loans for this product
        /// </summary>
        public bool EnforceDefaultInterestRateForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set minimum monthly period for individual loan for this product
        /// </summary>
        public int MinimumMonthlyPeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set maximum monthly period for individual loan for this product
        /// </summary>
        public int MaximumMonthlyPeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set default grace period for individual loan for this product[in days]
        /// </summary>
        public int DefaultGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default grace period on all individual loans for this product
        /// </summary>
        public bool EnforceDefaultGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set maximum for individual loan for this product[in days]
        /// </summary>
        public int MaximumGracePeriodForPersonalLoan { get; set; }
        /// <summary>
        /// Get Or Set default number of installments for individual loan for this product[in days]
        /// </summary>
        public int DefaultInstallmentsForPersonalLoan { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default number of installments for all individual loans of this product
        /// </summary>
        public bool EnforceDefaultInstallmentsForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set default installment type for individual loan for this product
        /// </summary>
        public InstallmentType DefaultInstallmentTypeForPersonalLoan { get; set; } = InstallmentType.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether to enforce default installment type for all individual loans of this product
        /// </summary>
        public bool EnforceDefaultInstallmentTypeForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set default interest calculation method for individual loan for this product
        /// </summary>
        public InterestCalculation DefaultInterestCalculationForPersonalLoans { get; set; } = InterestCalculation.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether to enforce default interest calculation for all individual loans for this product
        /// </summary>
        public bool EnforceDefaultInterestCalculationForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to interest payment should be made upfront for all individual loans of this product
        /// </summary>
        public bool RequireInterestPaymentUpfrontForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest payment to be made upfront for all individual loans of this product
        /// </summary>
        public bool EnforceRequireInterestPaymentUpfrontForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to require lumpsum interest payment to be made upfront for all individual loans of this product
        /// </summary>
        public bool RequireLumpsumPaymentOfInterestUpfrontForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce the requirement of lumpsum interest payment to be 
        /// made upfront for all individual loans of this product
        /// </summary>
        public bool EnforceRequireLumpsumPaymentOfInterestUpfrontForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to calculate interest in grace period for all individual loans of this product
        /// </summary>
        public bool CalculateInterestInGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to compound interest in grace period for all individual loans of this product
        /// </summary>
        public bool CompoundInterestOnGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce compounding of interest in grace period for all individual loans of this product
        /// </summary>
        public bool EnforceCompoundInterestOnGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be paid in grace period for all individual loans of this product
        /// </summary>
        public bool PayInterestInGrossPeriodOForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest payment in grace period for all individual loans of this product
        /// </summary>
        public bool EnforcePaymentOfInterestInGrossPeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether installments in grace period are to be separated for all individual loans of this product
        /// </summary>
        public bool SeparateInstatllmentsInGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce the separation of installments in grace period for all individual loans of this product
        /// </summary>
        public bool EnforceSeparateInstatllmentsInGracePeriodForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be deducted at disbursement for all individual loans of this product
        /// </summary>
        public bool DeductInterestAtDisbursementForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest deduction at disbursement for all individual loans of this product
        /// </summary>
        public bool EnforceDeductionOfInterestAtDisbursementForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be calculated in days for all individual loans of this product
        /// </summary>
        public bool CalculateInterestInDaysForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest calculation in days for all individual loans of this product
        /// </summary>
        public bool EnforceCalculateInterestInDaysForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set installment-based commission for individual loans
        /// </summary>
        public InstallmentBasedCommission InstallmentBasedCommissionForPersonalLoans { get; set; } = InstallmentBasedCommission.None;
        /// <summary>
        /// Get Or Set value compund installment based commission on all individual loans for this product
        /// </summary>
        public bool CompoundInstallmentBasedCommissionForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set days along is considered to be in arrears for individual loans
        /// </summary>
        public int DaysToArrearPersonalLoans { get; set; }

        /*group loan*/
        /// <summary>
        /// Get Or Set the minimum number of days a group must be as client before advancing a loan
        /// </summary>
        public int MinimumDaysAsClientGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the minimum number of days a member must be as member of a group before advancing a loan
        /// </summary>
        public int MinimumDaysAsMember { get; set; }
        /// <summary>
        /// Get Or Set default loan amount for group loan for this product
        /// </summary>
        public decimal LoanAmountForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default amount on all group loans for this product
        /// </summary>
        public bool EnforceDefaultLoanAmountForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the minimum loan amount offered for group loans for this product
        /// </summary>
        public decimal MinimumLoanAmountForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the maximum loan amount offered for group loans for this product
        /// </summary>
        public decimal MaximumLoanAmountForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the default loan amount offered per member for group loans for this product
        /// </summary>
        public decimal DefaultLoanAmountForGroupMembers { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guaranted group loans should be checked per member savings
        public bool CheckSavingsGuaranteePerMember { get; set; }
        /// <summary>
        /// Get or Set default loan cycle for group loans in this prodcut
        /// </summary>
        public int DefaultLoanCycle { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan cycles can exceed the standard cycles set for this product for group loans for this product
        /// </summary>
        public bool CanIncreaseLoanCyclesForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan amount validation is done per cycle for group loans for this product
        /// </summary>
        public bool TurnOnLoanAmountValidationPerCycleGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set default interest rate for group loan for this product
        /// </summary>
        public decimal DefaultInterestRateForGroupLoan { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default interest rate on all group loans for this product
        /// </summary>
        public bool EnforceDefaultInterestRateForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set minimum monthly period for group loan for this product
        /// </summary>
        public int MinimumMonthlyPeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set maximum monthly period for group loan for this product
        /// </summary>
        public int MaximumMonthlyPeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set default grace period for group loan for this product[in days]
        /// </summary>
        public int DefaultGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default grace period on all group loans for this product
        /// </summary>
        public bool EnforceDefaultGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set maximum for group loan for this product[in days]
        /// </summary>
        public int MaximumGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set default number of installments for group loan for this product[in days]
        /// </summary>
        public int DefaultInstallmentsForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default number of installments for all group loans of this product
        /// </summary>
        public bool EnforceDefaultInstallmentsForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set default installment type for individual loan for this product
        /// </summary>
        public InstallmentType DefaultInstallmentTypeForGroupLoans { get; set; } = InstallmentType.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether to enforce default installment type for all group loans of this product
        /// </summary>
        public bool EnforceDefaultInstallmentTypeForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set default interest calculation method for group loan for this product
        /// </summary>
        public InterestCalculation DefaultInterestCalculationForGroupLoans { get; set; } = InterestCalculation.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether to enforce default interest calculation for all group loans for this product
        /// </summary>
        public bool EnforceDefaultInterestCalculationForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to interest payment should be made upfront for all group loans of this product
        /// </summary>
        public bool RequireInterestPaymentUpfrontForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest payment to be made upfront for all group loans of this product
        /// </summary>
        public bool EnforceRequireInterestPaymentUpfrontForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to require lumpsum interest payment to be made upfront for all group loans of this product
        /// </summary>
        public bool RequireLumpsumPaymentOfInterestUpfrontForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce the requirement of lumpsum interest payment to be 
        /// made upfront for all group loans of this product
        /// </summary>
        public bool EnforceRequireLumpsumPaymentOfInterestUpfrontForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to calculate interest in grace period for all group loans of this product
        /// </summary>
        public bool CalculateInterestInGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to compound interest in grace period for all group loans of this product
        /// </summary>
        public bool CompoundInterestOnGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce compounding of interest in grace period for all group loans of this product
        /// </summary>
        public bool EnforceCompoundInterestOnGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be paid in grace period for all group loans of this product
        /// </summary>
        public bool PayInterestInGrossPeriodOForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest payment in grace period for all group loans of this product
        /// </summary>
        public bool EnforcePaymentOfInterestInGrossPeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether installments in grace period are to be separated for all group loans of this product
        /// </summary>
        public bool SeparateInstatllmentsInGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce the separation of installments in grace period for all group loans of this product
        /// </summary>
        public bool EnforceSeparateInstatllmentsInGracePeriodForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be deducted at disbursement for all group loans of this product
        /// </summary>
        public bool DeductInterestAtDisbursementForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest deduction at disbursement for all group loans of this product
        /// </summary>
        public bool EnforceDeductionOfInterestAtDisbursementForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be calculated in days for all group loans of this product
        /// </summary>
        public bool CalculateInterestInDaysForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest calculation in days for all group loans of this product
        /// </summary>
        public bool EnforceCalculateInterestInDaysForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set installment-based commission for group loans
        /// </summary>
        public InstallmentBasedCommission InstallmentBasedCommissionForGroupLoans { get; set; } = InstallmentBasedCommission.None;
        /// <summary>
        /// Get Or Set value compund installment based commission on all group loans for this product
        /// </summary>
        public bool CompoundInstallmentBasedCommissionForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set days along is considered to be in arrears for groups loans
        /// </summary>
        public int DaysToArrearGroupLoans { get; set; }

        /*business loans*/
        /// <summary>
        /// Get Or Set minimum number of days for all business loans of this product
        /// </summary>
        public int MinimumDaysAsClientBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set business sector this loan product covers for all business loans of this product
        /// </summary>
        public int DefaultBusinessSector { get; set; }
        /// <summary>
        /// Get Or Set default loan amount for business loan for this product
        /// </summary>
        public decimal LoanAmountForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default amount on all business loans for this product
        /// </summary>
        public bool EnforceDefaultLoanAmountForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set the minimum loan amount offered for business loans for this product
        /// </summary>
        public decimal MinimumLoanAmountForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set the maximum loan amount offered for business loans for this product
        /// </summary>
        public decimal MaximumLoanAmountForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan cycles can exceed the standard cycles set for this product for business loans for this product
        /// </summary>
        public bool CanIncreaseLoanCyclesForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loan amount validation is done per cycle for business loans for this product
        /// </summary>
        public bool TurnOnLoanAmountValidationPerCycleBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set default interest rate for business loan for this product
        /// </summary>
        public decimal DefaultInterestRateForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default interest rate on all business loans for this product
        /// </summary>
        public bool EnforceDefaultInterestRateForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set minimum monthly period for business loan for this product
        /// </summary>
        public int MinimumMonthlyPeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set maximum monthly period for business loan for this product
        /// </summary>
        public int MaximumMonthlyPeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set default grace period for business loan for this product[in days]
        /// </summary>
        public int DefaultGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default grace period on all business loans for this product
        /// </summary>
        public bool EnforceDefaultGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set maximum for business loan for this product[in days]
        /// </summary>
        public int MaximumGracePeriodForBusinessLoan { get; set; }
        /// <summary>
        /// Get Or Set default number of installments for business loan for this product[in days]
        /// </summary>
        public int DefaultInstallmentsForBusinessLoan { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce default number of installments for all business loans of this product
        /// </summary>
        public bool EnforceDefaultInstallmentsForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set default installment type for business loan for this product
        /// </summary>
        public InstallmentType DefaultInstallmentTypeForBusinesslLoan { get; set; } = InstallmentType.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether to enforce default installment type for all business loans of this product
        /// </summary>
        public bool EnforceDefaultInstallmentTypeForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set default interest calculation method for business loan for this product
        /// </summary>
        public InterestCalculation DefaultInterestCalculationForBusinessLoans { get; set; } = InterestCalculation.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether to enforce default interest calculation for all business loans for this product
        /// </summary>
        public bool EnforceDefaultInterestCalculationForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to interest payment should be made upfront for all business loans of this product
        /// </summary>
        public bool RequireInterestPaymentUpfrontForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest payment to be made upfront for all business loans of this product
        /// </summary>
        public bool EnforceRequireInterestPaymentUpfrontForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to require lumpsum interest payment to be made upfront for all business loans of this product
        /// </summary>
        public bool RequireLumpsumPaymentOfInterestUpfrontForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce the requirement of lumpsum interest payment to be 
        /// made upfront for all individual loans of this product
        /// </summary>
        public bool EnforceRequireLumpsumPaymentOfInterestUpfrontForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to calculate interest in grace period for all business loans of this product
        /// </summary>
        public bool CalculateInterestInGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to compound interest in grace period for all business loans of this product
        /// </summary>
        public bool CompoundInterestOnGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce compounding of interest in grace period for all business loans of this product
        /// </summary>
        public bool EnforceCompoundInterestOnGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be paid in grace period for all business loans of this product
        /// </summary>
        public bool PayInterestInGrossPeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest payment in grace period for all business loans of this product
        /// </summary>
        public bool EnforcePaymentOfInterestInGrossPeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether installments in grace period are to be separated for all business loans of this product
        /// </summary>
        public bool SeparateInstatllmentsInGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce the separation of installments in grace period for all business loans of this product
        /// </summary>
        public bool EnforceSeparateInstatllmentsInGracePeriodForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be deducted at disbursement for all business loans of this product
        /// </summary>
        public bool DeductInterestAtDisbursementForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest deduction at disbursement for all business loans of this product
        /// </summary>
        public bool EnforceDeductionOfInterestAtDisbursementForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether interest is to be calculated in days for all business loans of this product
        /// </summary>
        public bool CalculateInterestInDaysForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether to enforce interest calculation in days for all business loans of this product
        /// </summary>
        public bool EnforceCalculateInterestInDaysForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set installment-based commission for business loans
        /// </summary>
        public InstallmentBasedCommission InstallmentBasedCommissionForBusinessLoans { get; set; } = InstallmentBasedCommission.None;
        /// <summary>
        /// Get Or Set value compund installment based commission on all business loans for this product
        /// </summary>
        public bool CompoundInstallmentBasedCommissionForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set days along is considered to be in arrears for business loans
        /// </summary>
        public int DaysToArrearBusinessLoans { get; set; }

        /*auto repayments*/
        /// <summary>
        /// Get Or Set value whether repayments are automatically made from repayments
        /// </summary>
        public bool AutomaticallyRepayFromSavings { get; set; }
        /// <summary>
        /// Get Or Set savings product used when calculating automatic repayments
        /// </summary>
        public string AutomaticRepaymentSavingProduct { get; set; } = "";
        /// <summary>
        /// Get Or Set value whether to include minimum amounts when calculating repayments automatically
        /// </summary>
        public bool IncludeMinimumAmountOnAutomaticRepayment { get; set; }
        /// <summary>
        /// Get Or set the minimum number of days from which to start calculating repaymets automatically from savings
        /// </summary>
        public int MinimumArrearDaysToAutomaticRepayment { get; set; }

        /*loan penalties*/
        /// <summary>
        /// Get Or Set penalty calculation type
        /// </summary>
        public PenaltyCalculationType PenaltyCalculation { get; set; } = PenaltyCalculationType.None;
        /// <summary>
        /// Get Or Set penalty calculation method
        /// </summary>
        public PenaltyCalculationMethod PenaltyCalculationMethod { get; set; } = PenaltyCalculationMethod.NoPenalty;
        /// <summary>
        /// Get Or Set whether penalty calculation is done automatically by task
        /// </summary>
        public bool TurnOnTaskBasedPenaltyCalculation { get; set; }
        /// <summary>
        /// Get Or Set whether penalty calculation is done automatically at login
        /// </summary>
        public bool TurnOnLoginPenaltyCalculation { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether penalty on flat amounts is auto calculated
        /// </summary>
        public bool AutoCalculationPenaltyOnFlatAmounts { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether penalty is calculated per installment due
        /// </summary>
        public bool CalculatePenaltyPerInstallmentDue { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether penalty calculation is turned on for holidays and week ends
        /// </summary>
        public bool TurnOnPenaltyCalculationOnHolidaysAndWeekEnds { get; set; }
        /// <summary>
        /// Get Or Set last penalty calculation date
        /// </summary>
        public DateTime LastPenaltyCalculationDate { get; set; }
        /// <summary>
        /// Get Or Set minimum amount charged as penalty
        /// </summary>
        public decimal MinimumAmountChargedAsPenalty { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether penalty is to be calculated for months after loan has expired
        /// </summary>
        public bool CalculatePenaltyAfterExpiration { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether penalty is automatically calculated after grace period
        /// </summary>
        public bool AutoCalculatePenaltyAfterGrancePeriod { get; set; }
        /// <summary>
        /// Get Or Set grace period in days before system starts to auto calculate penalty
        /// </summary>
        public int AutoPenaltyGracePeriod { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether penalty and interest are capitalized on automatic calculation
        /// </summary>
        public bool CapitalizeInterestAndPenaltiesOnAutomaticPenaltyCalculation { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether loans which are due on auto-calculation date should be included when calculating penalty
        /// </summary>
        public bool IncludeLoansOnDueDateInAutomaticPenaltyCalculation { get; set; }

        /*collateral*/
        /// <summary>
        /// Get Or Set value indicating whether collateral is required for personal loans
        /// </summary>
        public bool RequireCollateralForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of collateral required for personal loans
        /// </summary>
        public decimal CollateralPercentageForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set method for enforcing collateral
        /// </summary>
        public EnforceCollateral EnforceCollateral { get; set; } = EnforceCollateral.Undefines;
        /// <summary>
        /// Get Or Set value indicating whether percentage of collateral required for personal loans must be enforced
        /// </summary>
        public bool EnforceCollateralPercentageForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether collateral is required for group loans
        /// </summary>
        public bool RequireCollateralForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of collateral required for group loans
        /// </summary>
        public decimal CollateralPercentageForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether percentage of collateral required for group loans must be enforced
        /// </summary>
        public bool EnforceCollateralPercentageForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether collateral is required for business loans
        /// </summary>
        public bool RequireCollateralForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of collateral required for business loans
        /// </summary>
        public decimal CollateralPercentageForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether percentage of collateral required for business loans must be enforced
        /// </summary>
        public bool EnforceCollateralPercentageForBusinessLoans { get; set; }

        /*1.Loan Guaratee by shares*/
        /// <summary>
        /// Get Or Set value indicating whether loan can be guaranteed by shares held by client
        /// </summary>
        public bool CanGuaranteeLoanByShares { get; set; }
        /// <summary>
        /// Get Or Set the share product used to guarantee loan
        /// </summary>
        public string GuaranteeShareProduct { get; set; }
        /// <summary>
        /// Get Or Set the percentage of share pladged as guarantee for personal loans
        /// </summary>
        public decimal ShareGuaranteePercentageForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of share pladged as guarantee for group loans
        /// </summary>
        public decimal ShareGuaranteePercentageForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of share pladged as guarantee for business loans
        /// </summary>
        public decimal ShareGuaranteePercentageForBusinesslLoans { get; set; }

        /*1.Loan Guaratee by savings*/
        /// <summary>
        /// Get Or Set value indicating whether loan can be guaranteed by savings held by client
        /// </summary>
        public bool CanGuaranteeLoanBySavings { get; set; }
        /// <summary>
        /// Get Or Set the savings product used to guarantee loan
        /// </summary>
        public string GuaranteeSavingsProduct { get; set; }
        /// <summary>
        /// Get Or Set the type of deposit for which savings guarantee deposit is based on
        /// </summary>
        public GuaranteeDepositType SavingsGuaranteeType { get; set; } = GuaranteeDepositType.Undefined;
        /// <summary>
        /// Get Or Set value indicating whether savings guaratee amount must be deposited at loan disbursement
        /// </summary>
        public bool RequireGuaranteeDepositAtDisbursement { get; set; }
        /// <summary>
        /// Get Or Set the percentage to be saved as loan guarantee deposit for personal loans
        /// </summary>
        public decimal PercentageOfGuaranteeDepositForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guaratee amount must bededucted at loan disbursement for personal loans
        /// </summary>
        public bool DeductGuaranteeDepositAtDisbursementForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage to be saved as loan guarantee deposit for group loans
        /// </summary>
        public decimal PercentageOfGuaranteeDepositForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guaratee amount must bededucted at loan disbursement for group loans
        /// </summary>
        public bool DeductGuaranteeDepositAtDisbursementForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage to be saved as loan guarantee deposit for business loans
        /// </summary>
        public decimal PercentageOfGuaranteeDepositForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guaratee amount must bededucted at loan disbursement for business loans
        /// </summary>
        public bool DeductGuaranteeDepositAtDisbursementForBusinessLoans { get; set; }
        /// <summary>
        /// Get Or Set the credit risk that can be taken for loans guaranteed by savings products
        /// </summary>
        public decimal AcceptableCreditRiskForSavingGuarantedLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of savings pladged as guarantee for personal loans
        /// </summary>
        public decimal SavingsGuaranteePercentageForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guarantee percentage should be enforced for personal loans
        /// </summary>
        public bool EnforceSavingsGuaranteePercentageForPersonalLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of savings pladged as guarantee for group loans
        /// </summary>
        public decimal SavingsGuaranteePercentageForGroupLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guarantee percentage should be enforced for group loans
        /// </summary>
        public bool EnforceSavingsGuaranteePercentageForGrouplLoans { get; set; }
        /// <summary>
        /// Get Or Set the percentage of savings pladged as guarantee for business loans
        /// </summary>
        public decimal SavingsGuaranteePercentageForBusinesslLoans { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether savings guarantee percentage should be enforced for business loans
        /// </summary>
        public bool EnforceSavingsGuaranteePercentageForBusinesslLoans { get; set; }

        /*ledger accounts*/
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForPrincipalOutstandingPersonalLoan { get; set; } = "";
        /// <summary>
        ///Get Or Set ledger account for
        /// </summary>
        public string LedgerForPrincipalOutstandingGrouplLoan { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForPrincipalOutstandingBusinesslLoan { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForProvissionForBadDebtsPersonalLoans { get; set; } = "";
        /// <summary>
        /// 
        /// </summary>
        public string LedgerForProvissionForBadDebtsGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForProvissionForBadDebtsBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForCostOnProvisionForBadDebtsPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForCostOnProvisionForBadDebtsGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForCostOnProvisionForBadDebtsBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForInterestPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForInterestGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForInterestBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForLoansWriteOffPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForLoansWriteOffGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForLoansWriteOffBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedInterestPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedInterestGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedInterestBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForInterestRecievedPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForInterestRecievedGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForInterestRecievedBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForRefinancePersonLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForRefinanceBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForRefinanceGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedPenaltyPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedPenaltyGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedPenaltyBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedLoanCommissionIndividualLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedLoanCommissionGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for
        /// </summary>
        public string LedgerForAccruedLoanCommissionBusinessLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for recovery of bad debts
        /// </summary>
        public string LedgerForRecoveryOfBadDebts { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for loan related cheques
        /// </summary>
        public string LedgerForLoanCheques { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for loan currency difference
        /// </summary>
        public string LedgerForCurrencyDifferences { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for loan over payment
        /// </summary>
        public string LedgerForLoanOverPayments { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account supplier loans markup
        /// </summary>
        public string LedgerForSupplierLoanMarkUp { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for accrued loan charges on personal loans
        /// </summary>
        public string LedgerForAccruedLoanChargesPersonalLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for accrued loan charges on group loans
        /// </summary>
        public string LedgerForAccruedLoanChargesGroupLoans { get; set; } = "";
        /// <summary>
        /// Get Or Set ledger account for accrued loan charges on business loans
        /// </summary>
        public string LedgerForAccruedLoanChargesBusinessLoans { get; set; } = "";

        /*sms reminders*/
        /// <summary>
        /// Get Or Set value indicating whether sending the first SMS before due date is turned on
        /// </summary>
        public bool TurnOnSendSmsBeforeFirstDuedate { get; set; }
        /// <summary>
        /// Get or set the number of days that are left before due date to send first SMS
        /// </summary>
        public int DaysToSendSmsBeforeFirstDuedate { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether sending the second SMS before due date is turned on
        /// </summary>
        public bool TurnOnSendSmsBeforeSecondDuedate { get; set; }
        /// <summary>
        /// Get or set the number of days that are left before due date to send second SMS
        /// </summary>
        public int DaysToSendSmsBeforeSecondDuedate { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether sending the third SMS before due date is turned on
        /// </summary>
        public bool TurnOnSendSmsBeforeThirdDuedate { get; set; }
        /// <summary>
        /// Get or set the number of days that are left before due date to send third SMS
        /// </summary>
        public int DaysToSendSmsBeforeThirdDuedate { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether sending the first SMS after due date is turned on
        /// </summary>
        public bool TurnOnSendSmsAfterFirstDuedate { get; set; }
        /// <summary>
        /// Get or set the number of days that are passed after due date to send first SMS
        /// </summary>
        public int DaysToSendSmsAfterFirstDuedate { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether sending the second SMS after due date is turned on
        /// </summary>
        public bool TurnOnSendSmsAfterSecondDuedate { get; set; }
        /// <summary>
        /// Get or set the number of days that are passed after due date to send second SMS
        /// </summary>
        public int DaysToSendSmsAfterSecondDuedate { get; set; }
        /// <summary>
        /// Get Or Set value indicating whether sending the third SMS after due date is turned on
        /// </summary>
        public bool TurnOnSendSmsAfterThirdDuedate { get; set; }
        /// <summary>
        /// Get or set the number of days that are passed after due date to send third SMS
        /// </summary>
        public int DaysToSendSmsAfterThirdDuedate { get; set; }
        /// <summary>
        /// Get Or Set group SMS sending option eg. To all members or to group management
        /// </summary>
        public GroupSms GroupSmsSendingOption { get; set; } = GroupSms.All;
        /// <summary>
        /// Get Or Set SMS sending time
        /// </summary>
        public string SmsSendingTime { get; set; } = "";
    }
}
