using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;

namespace MfiManager.Middleware.Data.Entities.System.Configurations.Products {

    public class LoanProductConfigurationParameter: IConfigurationParameter {
            [ConfigParam(name: "AvailableToSavingCustomersOnly", description: "Check whether product is only availed to saving clients", paramType: "bool")]
            public string AvailableToSavingCustomersOnly { get; set; }
            [ConfigParam(name: "LinkedSavingsProduct", description: "Product code for savings product linked to this loan product", paramType: "string")]
            public string LinkedSavingsProduct { get; set; }
            [ConfigParam(name: "InterestDays", description: "Number of interest days in a year", paramType: "int")]
            public string InterestDays { get; set; }
            [ConfigParam(name: "InterestWeeks", description: "Number of interest weeks in a year", paramType: "int")]
            public string InterestWeeks { get; set; }
            [ConfigParam(name: "LoanApprovalStages", description: "Number of loan approval stages involved, Tier One-any one who has access, Tier Two-secondary approval, Tier Three-third approver, Tier Four-Senior analyst", paramType: "int")]
            public string LoanApprovalStages { get; set; }
            [ConfigParam(name: "ForceModificationOfDueDates", description: "Check whether modification of due dates at disbursement must be enforced", paramType: "bool")]
            public string ForceModificationOfDueDates { get; set; }
            [ConfigParam(name: "ModificationOMethod", description: "Due dates modification method", paramType: "int")]
            public string ModificationOMethod { get; set; }
            [ConfigParam(name: "MailMergeRecords", description: "Check whether loan records should be mail merged", paramType: "bool")]
            public string MailMergeLoanRecords { get; set; }
            [ConfigParam(name: "MailMergeOption", description: "Loan records mail merge option or stage", paramType: "int")]
            public string MailMergeOption { get; set; }
            [ConfigParam(name: "ApplyRecalculateInterest", description: "Check whether loan interest must be recalculated at repayment", paramType: "bool")]
            public string ApplyRecalculateInterest { get; set; }
            [ConfigParam(name: "ReclaculateInterestOnlyIfNotIndays", description: "Check whether loan interest is to be recalculated only if interest is not calculated in days", paramType: "bool")]
            public string ReclaculateInterestOnlyIfNotIndays { get; set; }
            [ConfigParam(name: "RecalculationMethod", description: "Interest recalculation type used when recalculating loan interest", paramType: "int")]
            public string RecalculationMethod { get; set; }
            [ConfigParam(name: "NoInterestResetAtRecalculation", description: "Check whether interest is frozen for loans lin arrears after a certain number of days", paramType: "bool")]
            public string NoInterestResetAtRecalculation { get; set; }
            [ConfigParam(name: "FreezInterestWhenInArrears", description: "Check whether interest is frozen for loans lin arrears after a certain number of days", paramType: "bool")]
            public string FreezInterestWhenInArrears { get; set; }
            [ConfigParam(name: "DaysToConsiderInArrearsToFreezInterest", description: "Number of days that a loan must be in arrears for interest to be frozen", paramType: "int")]
            public string DaysToConsiderInArrearsToFreezInterest { get; set; }
            [ConfigParam(name: "DeclassifyPrincipalInArrears", description: "Check whether to declassify principal in arrears", paramType: "bool")]
            public string DeclassifyPrincipalInArrears { get; set; }
            [ConfigParam(name: "DeclassifyInterestInArrears", description: "Check whether to declassify interest in arrears", paramType: "bool")]
            public string DeclassifyInterestInArrears { get; set; }
            [ConfigParam(name: "CompoundInterestAtRepayment", description: "Check whether interest is compounded at repayment for loans with interest calculated with declining balance method", paramType: "bool")]
            public string CompoundInterestAtRepayment { get; set; }
            [ConfigParam(name: "IgnoreMaximumLimit", description: "Check whether maximum loan limit can be ignored when giving out loans", paramType: "bool")]
            public string IgnoreMaximumLimit { get; set; }
            [ConfigParam(name: "AllowPartialDisbursements", description: "Check whether partial disbursements are allowed", paramType: "bool")]
            public string AllowPartialDisbursements { get; set; }
            [ConfigParam(name: "UseRepaymentPriority", description: "Check whether product sets loan payment priority", paramType: "bool")]
            public string UseRepaymentPriority { get; set; }
            [ConfigParam(name: "RepaymentPriority", description: "Check whether repayment priority order", paramType: "bool")]
            public string RepaymentPriority { get; set; }
            [ConfigParam(name: "DaysToConsiderInArrearsForRepaymentPriorityLoans", description: "Number of days that a loan must be in arrears for loans using repayment priority", paramType: "int")]
            public string DaysToConsiderInArrearsForRepaymentPriorityLoans { get; set; }
            [ConfigParam(name: "UseDuplum", description: "Check whether loan considers the use of Duplum rule when calculating interest", paramType: "bool")]
            public string UseDuplum { get; set; }
            [ConfigParam(name: "UseDuplum", description: "Check whether dues falling from on a certain day eg. 26-30 can be pushed to theend of month", paramType: "bool")]
            public string PushDuesFromToMonthEnd { get; set; }
            [ConfigParam(name: "PushDuesFrom", description: "Day of month from which all dues falling on that date upwards are pushed to the end of month", paramType: "int")]
            public string PushDuesFrom { get; set; }
            [ConfigParam(name: "ChargeWitholdingTaxOnFees", description: "Check whether product charges witholding tax on professional fees", paramType: "int")]
            public string ChargeWitholdingTaxOnFees { get; set; }
            [ConfigParam(name: "ChargeStampDuty", description: "Check whether  product charges stamp duty product", paramType: "bool")]
            public string ChargeStampDuty { get; set; }
            [ConfigParam(name: "MinimumDaysAsClientPersonalLoans", description: "Minimum number of days an individual can be as a customer before advancing a loan", paramType: "int")]
            public string MinimumDaysAsClientPersonalLoans { get; set; }
            [ConfigParam(name: "DefaultLoanAmountForPersonalLoans", description: "Default loan amount for individual loan for this product", paramType: "decimal")]
            public string DefaultLoanAmountForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultLoanAmountForPersonalLoans", description: "Check whether to enforce default amount on all individual loans for this product", paramType: "bool")]
            public string EnforceDefaultLoanAmountForPersonalLoans { get; set; }
            [ConfigParam(name: "MinimumLoanAmountForPersonalLoans", description: "Minimum loan amount offered for individual loans for this product", paramType: "decimal")]
            public string MinimumLoanAmountForPersonalLoans { get; set; }
            [ConfigParam(name: "MaximumLoanAmountForPersonalLoans", description: "Maximum loan amount offered for individual loans for this product", paramType: "decimal")]
            public string MaximumLoanAmountForPersonalLoans { get; set; }
            [ConfigParam(name: "CannotExceedIncomePercentage", description: "Check whether loan amount offered must not exceed a given percentage of the individual's income ndividual loans for this product", paramType: "bool")]
            public string CannotExceedIncomePercentage { get; set; }
            [ConfigParam(name: "IncomePercentage", description: "Percentage of individual's income that loan amount cannot exceed for individual loans for this product", paramType: "decimal")]
            public string IncomePercentage { get; set; }
            [ConfigParam(name: "CanIncreaseLoanCyclesForPersonalLoans", description: "Check whether loan cycles can exceed the standard cycles set for this product for individual loans for this product", paramType: "bool")]
            public string CanIncreaseLoanCyclesForPersonalLoans { get; set; }
            [ConfigParam(name: "TurnOnLoanAmountValidationPerCyclePersonalLoans", description: "Check whether loan amount validation is done per cycle for individual loans for this product", paramType: "bool")]
            public string TurnOnLoanAmountValidationPerCyclePersonalLoans { get; set; }
            [ConfigParam(name: "DefaultInterestRateForPersonalLoan", description: "Default interest rate for individual loan for this product", paramType: "decimal")]
            public string DefaultInterestRateForPersonalLoan { get; set; }
            [ConfigParam(name: "EnforceDefaultInterestRateForPersonalLoans", description: "Check whether to enforce default interest rate on all individual loans for this product", paramType: "bool")]
            public string EnforceDefaultInterestRateForPersonalLoans { get; set; }
            [ConfigParam(name: "MinimumMonthlyPeriodForPersonalLoans", description: "Minimum monthly period for individual loan for this product", paramType: "int")]
            public string MinimumMonthlyPeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "MaximumMonthlyPeriodForPersonalLoans", description: "Maximum monthly period for individual loan for this product", paramType: "int")]
            public string MaximumMonthlyPeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "DefaultGracePeriodForPersonalLoans", description: "Default grace period for individual loan for this product[in days]", paramType: "int")]
            public string DefaultGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultGracePeriodForPersonalLoans", description: "Check whether to enforce default grace period on all individual loans for this product", paramType: "bool")]
            public string EnforceDefaultGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "MaximumGracePeriodForPersonalLoan", description: "Maximum grace period for individual loan for this product[in days]", paramType: "int")]
            public string MaximumGracePeriodForPersonalLoan { get; set; }
            [ConfigParam(name: "DefaultInstallmentsForPersonalLoan", description: "Default number of installments for individual loan for this product[in days]", paramType: "int")]
            public string DefaultInstallmentsForPersonalLoan { get; set; }
            [ConfigParam(name: "EnforceDefaultInstallmentsForPersonalLoans", description: "Check whether to enforce default number of installments for all individual loans of this product", paramType: "bool")]
            public string EnforceDefaultInstallmentsForPersonalLoans { get; set; }
            [ConfigParam(name: "DefaultInstallmentTypeForPersonalLoan", description: "Default installment type for individual loan for this product", paramType: "int")]
            public string DefaultInstallmentTypeForPersonalLoan { get; set; }
            [ConfigParam(name: "EnforceDefaultInstallmentTypeForPersonalLoans", description: "Check whether to enforce default installment type for all individual loans of this product", paramType: "bool")]
            public string EnforceDefaultInstallmentTypeForPersonalLoans { get; set; }
            [ConfigParam(name: "DefaultInterestCalculationForPersonalLoans", description: "Default interest calculation method for individual loan for this product", paramType: "int")]
            public string DefaultInterestCalculationForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultInterestCalculationForPersonalLoans", description: "Check whether to enforce default interest calculation for all individual loans for this product", paramType: "bool")]
            public string EnforceDefaultInterestCalculationForPersonalLoans { get; set; }
            [ConfigParam(name: "RequireInterestPaymentUpfrontForPersonalLoans", description: "Check whether to enforce interest payment to be made upfront for all individual loans of this product", paramType: "bool")]
            public string RequireInterestPaymentUpfrontForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceRequireInterestPaymentUpfrontForPersonalLoans", description: "Check whether to enforce interest payment to be made upfront for all individual loans of this product", paramType: "bool")]
            public string EnforceRequireInterestPaymentUpfrontForPersonalLoans { get; set; }
            [ConfigParam(name: "RequireLumpsumPaymentOfInterestUpfrontForPersonalLoans", description: "Check whether to require lumpsum interest payment to be made upfront for all individual loans of this product", paramType: "bool")]
            public string RequireLumpsumPaymentOfInterestUpfrontForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceRequireLumpsumPaymentOfInterestUpfrontForPersonalLoans", description: "Check whether to enforce the requirement of lumpsum interest payment to be made upfront for all individual loans of this product", paramType: "bool")]
            public string EnforceRequireLumpsumPaymentOfInterestUpfrontForPersonalLoans { get; set; }
            [ConfigParam(name: "CalculateInterestInGracePeriodForPersonalLoans", description: "Check whether to calculate interest in grace period for all individual loans of this product", paramType: "bool")]
            public string CalculateInterestInGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "CompoundInterestOnGracePeriodForPersonalLoans", description: "Check whether to compound interest in grace period for all individual loans of this product", paramType: "bool")]
            public string CompoundInterestOnGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceCompoundInterestOnGracePeriodForPersonalLoans", description: "Check whether to enforce compounding of interest in grace period for all individual loans of this product", paramType: "bool")]
            public string EnforceCompoundInterestOnGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "PayInterestInGrossPeriodOForPersonalLoans", description: "Check whether interest is to be paid in grace period for all individual loans of this product", paramType: "bool")]
            public string PayInterestInGrossPeriodOForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforcePaymentOfInterestInGrossPeriodForPersonalLoans", description: "Check whether to enforce interest payment in grace period for all individual loans of this product", paramType: "bool")]
            public string EnforcePaymentOfInterestInGrossPeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "SeparateInstatllmentsInGracePeriodForPersonalLoans", description: "Check whether installments in grace period are to be separated for all individual loans of this product", paramType: "bool")]
            public string SeparateInstatllmentsInGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceSeparateInstatllmentsInGracePeriodForPersonalLoans", description: "Check whether to enforce the separation of installments in grace period for all individual loans of this product", paramType: "bool")]
            public string EnforceSeparateInstatllmentsInGracePeriodForPersonalLoans { get; set; }
            [ConfigParam(name: "DeductInterestAtDisbursementForPersonalLoans", description: "Check whether interest is to be deducted at disbursement for all individual loans of this product", paramType: "bool")]
            public string DeductInterestAtDisbursementForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceDeductionOfInterestAtDisbursementForPersonalLoans", description: "Check whether to enforce interest deduction at disbursement for all individual loans of this product", paramType: "bool")]
            public string EnforceDeductionOfInterestAtDisbursementForPersonalLoans { get; set; }
            [ConfigParam(name: "CalculateInterestInDaysForPersonalLoans", description: "Check whether interest is to be calculated in days for all individual loans of this product", paramType: "bool")]
            public string CalculateInterestInDaysForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceCalculateInterestInDaysForPersonalLoans", description: "Check whether to enforce interest calculation in days for all individual loans of this product", paramType: "bool")]
            public string EnforceCalculateInterestInDaysForPersonalLoans { get; set; }
            [ConfigParam(name: "InstallmentBasedCommissionForPersonalLoans", description: "Installment-based commission for individual loans", paramType: "int")]
            public string InstallmentBasedCommissionForPersonalLoans { get; set; }
            [ConfigParam(name: "CompoundInstallmentBasedCommissionForPersonalLoans", description: "Check whether to compund installment based commission on all individual loans for this product", paramType: "bool")]
            public string CompoundInstallmentBasedCommissionForPersonalLoans { get; set; }
            [ConfigParam(name: "DaysToArrearPersonalLoans", description: "Days a loan is considered to be in arrears for individual loans", paramType: "int")]
            public string DaysToArrearPersonalLoans { get; set; }

            [ConfigParam(name: "MinimumDaysAsClientGroupLoans", description: "Minimum number of days a group must be as a customer before advancing a loan", paramType: "int")]
            public string MinimumDaysAsClientGroupLoans { get; set; }
            [ConfigParam(name: "MinimumDaysAsMember", description: "Minimum number of days a member must be as a member of group before advancing a loan", paramType: "int")]
            public string MinimumDaysAsMember { get; set; }
            [ConfigParam(name: "DefaultLoanAmountForGroupLoans", description: "Default loan amount for group loan for this product", paramType: "decimal")]
            public string DefaultLoanAmountForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultLoanAmountForGroupLoans", description: "Check whether to enforce default amount on all group loans for this product", paramType: "bool")]
            public string EnforceDefaultLoanAmountForGroupLoans { get; set; }
            [ConfigParam(name: "MinimumLoanAmountForGroupLoans", description: "Minimum loan amount offered for group loans for this product", paramType: "decimal")]
            public string MinimumLoanAmountForGroupLoans { get; set; }
            [ConfigParam(name: "MaximumLoanAmountForGroupLoans", description: "Maximum loan amount offered for group loans for this product", paramType: "decimal")]
            public string MaximumLoanAmountForGroupLoans { get; set; }
            [ConfigParam(name: "DefaultLoanAmountForGroupMembers", description: "Default loan amount offered per member for group loan for this product", paramType: "decimal")]
            public string DefaultLoanAmountForGroupMembers { get; set; }
             [ConfigParam(name: "EnforceDefaultLoanAmountForGroupMembers", description: "Check whether to enforce default amount on all members in group loans for this product", paramType: "bool")]
            public string EnforceDefaultLoanAmountForGroupMembers{ get; set; }
            [ConfigParam(name: "CheckSavingsGuaranteePerMember", description: "Check whether savings guaranted group loans should be checked per member savings", paramType: "bool")]
            public string CheckSavingsGuaranteePerMember { get; set; }
            [ConfigParam(name: "DefaultLoanCycle", description: "Default loan cycle for group loans in this prodcut", paramType: "int")]
            public string DefaultLoanCycle { get; set; }
            [ConfigParam(name: "CanIncreaseLoanCyclesForGroupLoans", description: "Check whether loan cycles can exceed the standard cycles set for this product for group loans for this product", paramType: "bool")]
            public string CanIncreaseLoanCyclesForGroupLoans { get; set; }
            [ConfigParam(name: "TurnOnLoanAmountValidationPerCycleGroupLoans", description: "Check whether loan amount validation is done per cycle for group loans for this product", paramType: "bool")]
            public string TurnOnLoanAmountValidationPerCycleGroupLoans { get; set; }
            [ConfigParam(name: "DefaultInterestRateForGroupLoan", description: "Default interest rate for group loan for this product", paramType: "decimal")]
            public string DefaultInterestRateForGroupLoan { get; set; }
            [ConfigParam(name: "EnforceDefaultInterestRateForGroupLoans", description: "Check whether to enforce default interest rate on all group loans for this product", paramType: "bool")]
            public string EnforceDefaultInterestRateForGroupLoans { get; set; }
            [ConfigParam(name: "MinimumMonthlyPeriodForGroupLoans", description: "Minimum monthly period for group loan for this product", paramType: "int")]
            public string MinimumMonthlyPeriodForGroupLoans { get; set; }
            [ConfigParam(name: "MaximumMonthlyPeriodForGroupLoans", description: "Maximum monthly period for group loan for this product", paramType: "int")]
            public string MaximumMonthlyPeriodForGroupLoans { get; set; }
            [ConfigParam(name: "DefaultGracePeriodForGroupLoans", description: "Default grace period for group loan for this product[in days]", paramType: "int")]
            public string DefaultGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultGracePeriodForGroupLoans", description: "Check whether to enforce default grace period on all group loans for this product", paramType: "bool")]
            public string EnforceDefaultGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "MaximumGracePeriodForGroupLoans", description: "Maximum grace period for group loan for this product[in days]", paramType: "int")]
            public string MaximumGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "DefaultInstallmentsForGroupLoans", description: "Default number of installments for group loan for this product[in days]", paramType: "int")]
            public string DefaultInstallmentsForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultInstallmentsForGroupLoans", description: "Check whether to enforce default number of installments for all group loans of this product", paramType: "bool")]
            public string EnforceDefaultInstallmentsForGroupLoans { get; set; }
            [ConfigParam(name: "DefaultInstallmentTypeForGroupLoans", description: "Default installment type for group loan for this product", paramType: "int")]
            public string DefaultInstallmentTypeForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultInstallmentTypeForGroupLoans", description: "Check whether to enforce default installment type for all group loans of this product", paramType: "bool")]
            public string EnforceDefaultInstallmentTypeForGroupLoans { get; set; }
            [ConfigParam(name: "DefaultInterestCalculationForGroupLoans", description: "Default interest calculation method for group loan for this product", paramType: "int")]
            public string DefaultInterestCalculationForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultInterestCalculationForGroupLoans", description: "Check whether to enforce default interest calculation for all group loans for this product", paramType: "bool")]
            public string EnforceDefaultInterestCalculationForGroupLoans { get; set; }
            [ConfigParam(name: "RequireInterestPaymentUpfrontForGroupLoans", description: "Check whether to enforce interest payment to be made upfront for all group loans of this product", paramType: "bool")]
            public string RequireInterestPaymentUpfrontForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceRequireInterestPaymentUpfrontForGroupLoans", description: "Check whether to enforce interest payment to be made upfront for all group loans of this product", paramType: "bool")]
            public string EnforceRequireInterestPaymentUpfrontForGroupLoans { get; set; }
            [ConfigParam(name: "RequireLumpsumPaymentOfInterestUpfrontForGroupLoans", description: "Check whether to require lumpsum interest payment to be made upfront for all group loans of this product", paramType: "bool")]
            public string RequireLumpsumPaymentOfInterestUpfrontForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceRequireLumpsumPaymentOfInterestUpfrontForGroupLoans", description: "Check whether to enforce the requirement of lumpsum interest payment to be made upfront for all group loans of this product", paramType: "bool")]
            public string EnforceRequireLumpsumPaymentOfInterestUpfrontForGroupLoans { get; set; }
            [ConfigParam(name: "CalculateInterestInGracePeriodForGroupLoans", description: "Check whether to calculate interest in grace period for all group loans of this product", paramType: "bool")]
            public string CalculateInterestInGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "CompoundInterestOnGracePeriodForGroupLoans", description: "Check whether to compound interest in grace period for all group loans of this product", paramType: "bool")]
            public string CompoundInterestOnGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceCompoundInterestOnGracePeriodForGroupLoans", description: "Check whether to enforce compounding of interest in grace period for all group loans of this product", paramType: "bool")]
            public string EnforceCompoundInterestOnGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "PayInterestInGrossPeriodOForGroupLoans", description: "Check whether interest is to be paid in grace period for all group loans of this product", paramType: "bool")]
            public string PayInterestInGrossPeriodOForGroupLoans { get; set; }
            [ConfigParam(name: "EnforcePaymentOfInterestInGrossPeriodForGroupLoans", description: "Check whether to enforce interest payment in grace period for all group loans of this product", paramType: "bool")]
            public string EnforcePaymentOfInterestInGrossPeriodForGroupLoans { get; set; }
            [ConfigParam(name: "SeparateInstatllmentsInGracePeriodForGroupLoans", description: "Check whether installments in grace period are to be separated for all group loans of this product", paramType: "bool")]
            public string SeparateInstatllmentsInGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceSeparateInstatllmentsInGracePeriodForGroupLoans", description: "Check whether to enforce the separation of installments in grace period for all group loans of this product", paramType: "bool")]
            public string EnforceSeparateInstatllmentsInGracePeriodForGroupLoans { get; set; }
            [ConfigParam(name: "DeductInterestAtDisbursementForGroupLoans", description: "Check whether interest is to be deducted at disbursement for all group loans of this product", paramType: "bool")]
            public string DeductInterestAtDisbursementForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceDeductionOfInterestAtDisbursementForGroupLoans", description: "Check whether to enforce interest deduction at disbursement for all group loans of this product", paramType: "bool")]
            public string EnforceDeductionOfInterestAtDisbursementForGroupLoans { get; set; }
            [ConfigParam(name: "CalculateInterestInDaysForGroupLoans", description: "Check whether interest is to be calculated in days for all group loans of this product", paramType: "bool")]
            public string CalculateInterestInDaysForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceCalculateInterestInDaysForGroupLoans", description: "Check whether to enforce interest calculation in days for all group loans of this product", paramType: "bool")]
            public string EnforceCalculateInterestInDaysForGroupLoans { get; set; }
            [ConfigParam(name: "InstallmentBasedCommissionForGroupLoans", description: "Installment-based commission for group loans", paramType: "int")]
            public string InstallmentBasedCommissionForGroupLoans { get; set; }
            [ConfigParam(name: "CompoundInstallmentBasedCommissionForGroupLoans", description: "Check whether to compund installment based commission on all group loans for this product", paramType: "bool")]
            public string CompoundInstallmentBasedCommissionForGroupLoans { get; set; }
            [ConfigParam(name: "DaysToArrearGroupLoans", description: "Days a loan is considered to be in arrears for group loans", paramType: "int")]
            public string DaysToArrearGroupLoans { get; set; }

            [ConfigParam(name: "MinimumDaysAsClientBusinessLoans", description: "Minimum number of days a business must be as a customer before advancing a loan", paramType: "int")]
            public string MinimumDaysAsClientBusinessLoans { get; set; }
            [ConfigParam(name: "DefaultBusinessSector", description: "Default business sector ID this loan product covers for all business loans of this product", paramType: "long")]
            public string DefaultBusinessSector { get; set; }
            [ConfigParam(name: "DefaultLoanAmountForBusinessLoans", description: "Default loan amount for individual loan for this product", paramType: "decimal")]
            public string DefaultLoanAmountForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultLoanAmountForBusinessLoans", description: "Check whether to enforce default amount on all business loans for this product", paramType: "bool")]
            public string EnforceDefaultLoanAmountForBusinessLoans { get; set; }
            [ConfigParam(name: "MinimumLoanAmountForBusinessLoans", description: "Minimum loan amount offered for business loans for this product", paramType: "decimal")]
            public string MinimumLoanAmountForBusinessLoans { get; set; }
            [ConfigParam(name: "MaximumLoanAmountForBusinessLoans", description: "Maximum loan amount offered for individual loans for this product", paramType: "decimal")]
            public string MaximumLoanAmountForBusinessLoans { get; set; }
            [ConfigParam(name: "CanIncreaseLoanCyclesForBusinessLoans", description: "Check whether loan cycles can exceed the standard cycles set for this product for business loans for this product", paramType: "bool")]
            public string CanIncreaseLoanCyclesForBusinessLoans { get; set; }
            [ConfigParam(name: "TurnOnLoanAmountValidationPerCycleBusinessLoans", description: "Check whether loan amount validation is done per cycle for business loans for this product", paramType: "bool")]
            public string TurnOnLoanAmountValidationPerCycleBusinessLoans { get; set; }
            [ConfigParam(name: "DefaultInterestRateForBusinessLoans", description: "Default interest rate for business loan for this product", paramType: "decimal")]
            public string DefaultInterestRateForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultInterestRateForBusinessLoans", description: "Check whether to enforce default interest rate on all business loans for this product", paramType: "bool")]
            public string EnforceDefaultInterestRateForBusinessLoans { get; set; }
            [ConfigParam(name: "MinimumMonthlyPeriodForBusinessLoans", description: "Minimum monthly period for business loan for this product", paramType: "int")]
            public string MinimumMonthlyPeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "MaximumMonthlyPeriodForBusinessLoans", description: "Maximum monthly period for business loan for this product", paramType: "int")]
            public string MaximumMonthlyPeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "DefaultGracePeriodForBusinessLoans", description: "Default grace period for individual loan for this product[in days]", paramType: "int")]
            public string DefaultGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultGracePeriodForBusinessLoans", description: "Check whether to enforce default grace period on all business loans for this product", paramType: "bool")]
            public string EnforceDefaultGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "MaximumGracePeriodForBusinessLoan", description: "Maximum grace period for business loan for this product[in days]", paramType: "int")]
            public string MaximumGracePeriodForBusinessLoan { get; set; }
            [ConfigParam(name: "DefaultInstallmentsForBusinessLoan", description: "Default number of installments for business loan for this product[in days]", paramType: "int")]
            public string DefaultInstallmentsForBusinessLoan { get; set; }
            [ConfigParam(name: "EnforceDefaultInstallmentsForBusinessLoans", description: "Check whether to enforce default number of installments for all business loans of this product", paramType: "bool")]
            public string EnforceDefaultInstallmentsForBusinessLoans { get; set; }
            [ConfigParam(name: "DefaultInstallmentTypeForBusinesslLoan", description: "Default installment type for business loan for this product", paramType: "int")]
            public string DefaultInstallmentTypeForBusinesslLoan { get; set; }
            [ConfigParam(name: "EnforceDefaultInstallmentTypeForBusinessLoans", description: "Check whether to enforce default installment type for all business loans of this product", paramType: "bool")]
            public string EnforceDefaultInstallmentTypeForBusinessLoans { get; set; }
            [ConfigParam(name: "DefaultInterestCalculationForBusinessLoans", description: "Default interest calculation method for business loan for this product", paramType: "int")]
            public string DefaultInterestCalculationForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceDefaultInterestCalculationForBusinessLoans", description: "Check whether to enforce default interest calculation for all business loans for this product", paramType: "bool")]
            public string EnforceDefaultInterestCalculationForBusinessLoans { get; set; }
            [ConfigParam(name: "RequireInterestPaymentUpfrontForBusinessLoans", description: "Check whether to enforce interest payment to be made upfront for all business loans of this product", paramType: "bool")]
            public string RequireInterestPaymentUpfrontForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceRequireInterestPaymentUpfrontForBusinessLoans", description: "Check whether to enforce interest payment to be made upfront for all business loans of this product", paramType: "bool")]
            public string EnforceRequireInterestPaymentUpfrontForBusinessLoans { get; set; }
            [ConfigParam(name: "RequireLumpsumPaymentOfInterestUpfrontForBusinessLoans", description: "Check whether to require lumpsum interest payment to be made upfront for all business loans of this product", paramType: "bool")]
            public string RequireLumpsumPaymentOfInterestUpfrontForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceRequireLumpsumPaymentOfInterestUpfrontForBusinessLoans", description: "Check whether to enforce the requirement of lumpsum interest payment to be made upfront for all business loans of this product", paramType: "bool")]
            public string EnforceRequireLumpsumPaymentOfInterestUpfrontForBusinessLoans { get; set; }
            [ConfigParam(name: "CalculateInterestInGracePeriodForBusinessLoans", description: "Check whether to calculate interest in grace period for all business loans of this product", paramType: "bool")]
            public string CalculateInterestInGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "CompoundInterestOnGracePeriodForBusinessLoans", description: "Check whether to compound interest in grace period for all business loans of this product", paramType: "bool")]
            public string CompoundInterestOnGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceCompoundInterestOnGracePeriodForBusinessLoans", description: "Check whether to enforce compounding of interest in grace period for all business loans of this product", paramType: "bool")]
            public string EnforceCompoundInterestOnGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "PayInterestInGrossPeriodForBusinessLoans", description: "Check whether interest is to be paid in grace period for all business loans of this product", paramType: "bool")]
            public string PayInterestInGrossPeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforcePaymentOfInterestInGrossPeriodForBusinessLoans", description: "Check whether to enforce interest payment in grace period for all business loans of this product", paramType: "bool")]
            public string EnforcePaymentOfInterestInGrossPeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "SeparateInstatllmentsInGracePeriodForBusinessLoans", description: "Check whether installments in grace period are to be separated for all business loans of this product", paramType: "bool")]
            public string SeparateInstatllmentsInGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceSeparateInstatllmentsInGracePeriodForBusinessLoans", description: "Check whether to enforce the separation of installments in grace period for all business loans of this product", paramType: "bool")]
            public string EnforceSeparateInstatllmentsInGracePeriodForBusinessLoans { get; set; }
            [ConfigParam(name: "DeductInterestAtDisbursementForBusinessLoans", description: "Check whether interest is to be deducted at disbursement for all business loans of this product", paramType: "bool")]
            public string DeductInterestAtDisbursementForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceDeductionOfInterestAtDisbursementForBusinessLoans", description: "Check whether to enforce interest deduction at disbursement for all business loans of this product", paramType: "bool")]
            public string EnforceDeductionOfInterestAtDisbursementForBusinessLoans { get; set; }
            [ConfigParam(name: "CalculateInterestInDaysForBusinessLoans", description: "Check whether interest is to be calculated in days for all business loans of this product", paramType: "bool")]
            public string CalculateInterestInDaysForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceCalculateInterestInDaysForBusinessLoans", description: "Check whether to enforce interest calculation in days for all business loans of this product", paramType: "bool")]
            public string EnforceCalculateInterestInDaysForBusinessLoans { get; set; }
            [ConfigParam(name: "InstallmentBasedCommissionForBusinessLoans", description: "Installment-based commission for business loans", paramType: "int")]
            public string InstallmentBasedCommissionForBusinessLoans { get; set; }
            [ConfigParam(name: "CompoundInstallmentBasedCommissionForBusinessLoans", description: "Check whether to compund installment based commission on all business loans for this product", paramType: "bool")]
            public string CompoundInstallmentBasedCommissionForBusinessLoans { get; set; }
            [ConfigParam(name: "DaysToArrearBusinessLoans", description: "Days a loan is considered to be in arrears for business loans", paramType: "int")]
            public string DaysToArrearBusinessLoans { get; set; }

            [ConfigParam(name: "AutomaticallyRepayFromSavings", description: "Check whether repayments are automatically made from repayments", paramType: "bool")]
            public string AutomaticallyRepayFromSavings { get; set; }
            [ConfigParam(name: "AutomaticRepaymentSavingProduct", description: "Savings product used when calculating automatic repayments", paramType: "string")]
            public string AutomaticRepaymentSavingProduct { get; set; }
            [ConfigParam(name: "IncludeMinimumAmountOnAutomaticRepayment", description: "Check whether to include minimum amounts when calculating repayments automatically", paramType: "bool")]
            public string IncludeMinimumAmountOnAutomaticRepayment { get; set; }
            [ConfigParam(name: "MinimumArrearDaysToAutomaticRepayment", description: "Minimum number of days from which to start calculating repaymets automatically from savings", paramType: "int")]
            public string MinimumArrearDaysToAutomaticRepayment { get; set; }
            [ConfigParam(name: "PenaltyCalculationType", description: "Penalty calculation type", paramType: "int")]
            public string PenaltyCalculationType { get; set; }
            [ConfigParam(name: "PenaltyCalculationMethod", description: "Penalty calculation method", paramType: "int")]
            public string PenaltyCalculationMethod { get; set; }
            [ConfigParam(name: "TurnOnTaskBasedPenaltyCalculation", description: "Check whether penalty calculation is done automatically by task", paramType: "bool")]
            public string TurnOnTaskBasedPenaltyCalculation { get; set; }
            [ConfigParam(name: "TurnOnLoginPenaltyCalculation", description: "Check whether penalty calculation is done automatically at login", paramType: "bool")]
            public string TurnOnLoginPenaltyCalculation { get; set; }
            [ConfigParam(name: "AutoCalculationPenaltyOnFlatAmounts", description: "Check whether penalty on flat amounts is auto calculated", paramType: "bool")]
            public string AutoCalculationPenaltyOnFlatAmounts { get; set; }
            [ConfigParam(name: "CalculatePenaltyPerInstallmentDue", description: "Check whether penalty is calculated per installment due", paramType: "bool")]
            public string CalculatePenaltyPerInstallmentDue { get; set; }
            [ConfigParam(name: "TurnOnPenaltyCalculationOnHolidaysAndWeekEnds", description: "Check whether penalty calculation is turned on for holidays and week ends", paramType: "bool")]
            public string TurnOnPenaltyCalculationOnHolidaysAndWeekEnds { get; set; }
            [ConfigParam(name: "LastPenaltyCalculationDate", description: "Penalty calculation date", paramType: "datetime")]
            public string LastPenaltyCalculationDate { get; set; }
            [ConfigParam(name: "MinimumAmountChargedAsPenalty", description: "Minimum amount charged as penalty", paramType: "decimal")]
            public string MinimumAmountChargedAsPenalty { get; set; }
            [ConfigParam(name: "CalculatePenaltyAfterExpiration", description: "Check whether penalty is to be calculated for months after loan has expired", paramType: "bool")]
            public string CalculatePenaltyAfterExpiration { get; set; }
            [ConfigParam(name: "AutoCalculatePenaltyAfterGrancePeriod", description: "Check whether penalty is automatically calculated after grace period", paramType: "bool")]
            public string AutoCalculatePenaltyAfterGrancePeriod { get; set; }
            [ConfigParam(name: "AutoPenaltyGracePeriod", description: "Grace period in days before system starts to auto calculate penalty", paramType: "int")]
            public string AutoPenaltyGracePeriod { get; set; }
            [ConfigParam(name: "CapitalizeInterestAndPenaltiesOnAutomaticPenaltyCalculation", description: "Check whether penalty and interest are capitalized on automatic calculation", paramType: "bool")]
            public string CapitalizeInterestAndPenaltiesOnAutomaticPenaltyCalculation { get; set; }
            [ConfigParam(name: "IncludeLoansOnDueDateInAutomaticPenaltyCalculation", description: "Check whether loans which are due on auto-calculation date should be included when calculating penalty", paramType: "bool")]
            public string IncludeLoansOnDueDateInAutomaticPenaltyCalculation { get; set; }

            [ConfigParam(name: "RequireCollateralForPersonalLoans", description: "Check whether collateral is required for personal loans", paramType: "bool")]
            public string RequireCollateralForPersonalLoans { get; set; }
            [ConfigParam(name: "CollateralPercentageForPersonalLoans", description: "The percentage of collateral required for personal loans", paramType: "decimal")]
            public string CollateralPercentageForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceCollateral", description: "Method used for enforcing collateral", paramType: "int")]
            public string EnforceCollateral { get; set; }
            [ConfigParam(name: "EnforceCollateralPercentageForPersonalLoans", description: "Check whether percentage of collateral required for personal loans must be enforced", paramType: "bool")]
            public string EnforceCollateralPercentageForPersonalLoans { get; set; }
            [ConfigParam(name: "RequireCollateralForGroupLoans", description: "Check whether collateral is required for group loans", paramType: "bool")]
            public string RequireCollateralForGroupLoans { get; set; }
            [ConfigParam(name: "CollateralPercentageForGroupLoans", description: "The percentage of collateral required for group loans", paramType: "decimal")]
            public string CollateralPercentageForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceCollateralPercentageForGroupLoans", description: "Check whether percentage of collateral required for group loans must be enforced", paramType: "bool")]
            public string EnforceCollateralPercentageForGroupLoans { get; set; }
            [ConfigParam(name: "RequireCollateralForBusinessLoans", description: "Check whether collateral is required for business loans", paramType: "bool")]
            public string RequireCollateralForBusinessLoans { get; set; }
            [ConfigParam(name: "CollateralPercentageForBusinessLoans", description: "The percentage of collateral required for business loans", paramType: "decimal")]
            public string CollateralPercentageForBusinessLoans { get; set; }
            [ConfigParam(name: "EnforceCollateralPercentageForBusinessLoans", description: "Check whether percentage of collateral required for business loans must be enforced", paramType: "bool")]
            public string EnforceCollateralPercentageForBusinessLoans { get; set; }


            [ConfigParam(name: "CanGuaranteeLoanByShares", description: "Check whether loan can be guaranteed by shares held by client", paramType: "bool")]
            public string CanGuaranteeLoanByShares { get; set; }
            [ConfigParam(name: "GuaranteeShareProduct", description: "The share product used to guarantee loan", paramType: "string")]
            public string GuaranteeShareProduct { get; set; }
            [ConfigParam(name: "ShareGuaranteePercentageForPersonalLoans", description: "The percentage of share pladged as guarantee for personal loans", paramType: "decimal")]
            public string ShareGuaranteePercentageForPersonalLoans { get; set; }
            [ConfigParam(name: "ShareGuaranteePercentageForGroupLoans", description: "The percentage of share pladged as guarantee for group loans", paramType: "decimal")]
            public string ShareGuaranteePercentageForGroupLoans { get; set; }
            [ConfigParam(name: "ShareGuaranteePercentageForBusinesslLoans", description: "The percentage of share pladged as guarantee for business loans", paramType: "decimal")]
            public string ShareGuaranteePercentageForBusinesslLoans { get; set; }
            [ConfigParam(name: "CanGuaranteeLoanBySavings", description: "Check whether loan can be guaranteed by savings held by client", paramType: "bool")]
            public string CanGuaranteeLoanBySavings { get; set; }
            [ConfigParam(name: "GuaranteeSavingsProduct", description: "The savings product used to guarantee loan", paramType: "string")]
            public string GuaranteeSavingsProduct { get; set; }
            [ConfigParam(name: "SavingsGuaranteeType", description: "The savings product used to guarantee loan", paramType: "int")]
            public string SavingsGuaranteeType { get; set; }
            [ConfigParam(name: "RequireGuaranteeDepositAtDisbursement", description: "Check whether savings guaratee amount must be deposited at loan disbursement", paramType: "int")]
            public string RequireGuaranteeDepositAtDisbursement { get; set; }
            [ConfigParam(name: "PercentageOfGuaranteeDepositForPersonalLoans", description: "The percentage to be saved as loan guarantee deposit for personal loans", paramType: "decimal")]
            public string PercentageOfGuaranteeDepositForPersonalLoans { get; set; }
            [ConfigParam(name: "DeductGuaranteeDepositAtDisbursementForPersonalLoans", description: "Check whether savings guaratee amount must bededucted at loan disbursement for personal loans", paramType: "bool")]
            public string DeductGuaranteeDepositAtDisbursementForPersonalLoans { get; set; }
            [ConfigParam(name: "PercentageOfGuaranteeDepositForGroupLoans", description: "The percentage to be saved as loan guarantee deposit for group loans", paramType: "decimal")]
            public string PercentageOfGuaranteeDepositForGroupLoans { get; set; }
            [ConfigParam(name: "DeductGuaranteeDepositAtDisbursementForGroupLoans", description: "Check whether savings guaratee amount must bededucted at loan disbursement for group loans", paramType: "bool")]
            public string DeductGuaranteeDepositAtDisbursementForGroupLoans { get; set; }
            [ConfigParam(name: "PercentageOfGuaranteeDepositForBusinessLoans", description: "The percentage to be saved as loan guarantee deposit for business loans", paramType: "decimal")]
            public string PercentageOfGuaranteeDepositForBusinessLoans { get; set; }
            [ConfigParam(name: "DeductGuaranteeDepositAtDisbursementForBusinessLoans", description: "Check whether savings guaratee amount must bededucted at loan disbursement for business loans", paramType: "bool")]
            public string DeductGuaranteeDepositAtDisbursementForBusinessLoans { get; set; }
            [ConfigParam(name: "AcceptableCreditRiskForSavingGuarantedLoans", description: "The credit risk that can be taken for loans guaranteed by savings products", paramType: "decimal")]
            public string AcceptableCreditRiskForSavingGuarantedLoans { get; set; }
            [ConfigParam(name: "SavingsGuaranteePercentageForPersonalLoans", description: "The percentage of savings pladged as guarantee for personal loans", paramType: "decimal")]
            public string SavingsGuaranteePercentageForPersonalLoans { get; set; }
            [ConfigParam(name: "EnforceSavingsGuaranteePercentageForPersonalLoans", description: "Check whether savings guarantee percentage should be enforced for personal loans", paramType: "bool")]
            public string EnforceSavingsGuaranteePercentageForPersonalLoans { get; set; }
            [ConfigParam(name: "SavingsGuaranteePercentageForGroupLoans", description: "The percentage of savings pladged as guarantee for group loans", paramType: "decimal")]
            public string SavingsGuaranteePercentageForGroupLoans { get; set; }
            [ConfigParam(name: "EnforceSavingsGuaranteePercentageForGrouplLoans", description: "Check whether savings guarantee percentage should be enforced for group loans", paramType: "bool")]
            public string EnforceSavingsGuaranteePercentageForGrouplLoans { get; set; }
            [ConfigParam(name: "SavingsGuaranteePercentageForBusinesslLoans", description: "The percentage of savings pladged as guarantee for business loans", paramType: "decimal")]
            public string SavingsGuaranteePercentageForBusinesslLoans { get; set; }
            [ConfigParam(name: "EnforceSavingsGuaranteePercentageForBusinesslLoans", description: "Check whether savings guarantee percentage should be enforced for business loans", paramType: "bool")]
            public string EnforceSavingsGuaranteePercentageForBusinesslLoans { get; set; }

            [ConfigParam(name: "LedgerForPrincipalOutstandingPersonalLoan", description: "Ledger account for Principal Outstanding amount on personal loans", paramType: "string")]
            public string LedgerForPrincipalOutstandingPersonalLoan { get; set; }
            [ConfigParam(name: "LedgerForPrincipalOutstandingGrouplLoan", description: "Ledger account for Principal Outstanding amount on group loans", paramType: "string")]
            public string LedgerForPrincipalOutstandingGrouplLoan { get; set; }
            [ConfigParam(name: "LedgerForPrincipalOutstandingBusinesslLoan", description: "Ledger account for Principal Outstanding amount on business loans", paramType: "string")]
            public string LedgerForPrincipalOutstandingBusinesslLoan { get; set; }
            [ConfigParam(name: "LedgerForProvissionForBadDebtsPersonalLoans", description: "Ledger account for Provision for Baddbts on personal loans", paramType: "string")]
            public string LedgerForProvissionForBadDebtsPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForProvissionForBadDebtsGroupLoans", description: "Ledger account for Provision for Baddbts on group loans", paramType: "string")]
            public string LedgerForProvissionForBadDebtsGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForProvissionForBadDebtsBusinessLoans", description: "Ledger account for Provision for Baddbts on business loans", paramType: "string")]
            public string LedgerForProvissionForBadDebtsBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForCostOnProvisionForBadDebtsPersonalLoans", description: "Ledger account for Cost on Provision for Baddbts on personal loans", paramType: "string")]
            public string LedgerForCostOnProvisionForBadDebtsPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForCostOnProvisionForBadDebtsGroupLoans", description: "Ledger account for Cost on Provision for Baddbts on group loans", paramType: "string")]
            public string LedgerForCostOnProvisionForBadDebtsGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForCostOnProvisionForBadDebtsBusinessLoans", description: "Ledger account for Cost on Provision for Baddbts on business loans", paramType: "string")]
            public string LedgerForCostOnProvisionForBadDebtsBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForInterestPersonalLoans", description: "Ledger account for interest on personal loans", paramType: "string")]
            public string LedgerForInterestPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForInterestPersonalLoans", description: "Ledger account for interest on group loans", paramType: "string")]
            public string LedgerForInterestGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForInterestBusinessLoans", description: "Ledger account for interest on business loans", paramType: "string")]
            public string LedgerForInterestBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForLoansWriteOffPersonalLoans", description: "Ledger account for writtenoff on personal loans", paramType: "string")]
            public string LedgerForLoansWriteOffPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForLoansWriteOffGroupLoans", description: "Ledger account for writtenoff on group loans", paramType: "string")]
            public string LedgerForLoansWriteOffGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForLoansWriteOffBusinessLoans", description: "Ledger account for writtenoff on business loans", paramType: "string")]
            public string LedgerForLoansWriteOffBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedInterestPersonalLoans", description: "Ledger account for accrued interest on personal loans", paramType: "string")]
            public string LedgerForAccruedInterestPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedInterestGroupLoans", description: "Ledger account for accrued interest on group loans", paramType: "string")]
            public string LedgerForAccruedInterestGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedInterestBusinessLoans", description: "Ledger account for accrued interest on business loans", paramType: "string")]
            public string LedgerForAccruedInterestBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForInterestRecievedPersonalLoans", description: "Ledger account for interest recieved on personal loans", paramType: "string")]
            public string LedgerForInterestRecievedPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForInterestRecievedGroupLoans", description: "Ledger account for interest recieved on group loans", paramType: "string")]
            public string LedgerForInterestRecievedGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForInterestRecievedBusinessLoans", description: "Ledger account for interest recieved on business loans", paramType: "string")]
            public string LedgerForInterestRecievedBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForRefinancePersonLoans", description: "Ledger account for refinance on personal loans", paramType: "string")]
            public string LedgerForRefinancePersonLoans { get; set; }
            [ConfigParam(name: "LedgerForRefinanceBusinessLoans", description: "Ledger account for refinance on business loans", paramType: "string")]
            public string LedgerForRefinanceBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForRefinanceGroupLoans", description: "Ledger account for refinance on group loans", paramType: "string")]
            public string LedgerForRefinanceGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedPenaltyPersonalLoans", description: "Ledger account for accrued penalty on personal loans", paramType: "string")]
            public string LedgerForAccruedPenaltyPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedPenaltyGroupLoans", description: "Ledger account for accrued penalty on group loans", paramType: "string")]
            public string LedgerForAccruedPenaltyGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedPenaltyBusinessLoans", description: "Ledger account for accrued penalty on business loans", paramType: "string")]
            public string LedgerForAccruedPenaltyBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedLoanCommissionIndividualLoans", description: "Ledger account for accrued loan commission on personal loans", paramType: "string")]
            public string LedgerForAccruedLoanCommissionIndividualLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedLoanCommissionGroupLoans", description: "Ledger account for accrued loan commission on personal loans", paramType: "string")]
            public string LedgerForAccruedLoanCommissionGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedLoanCommissionBusinessLoans", description: "Ledger account for accrued loan commission on business loans", paramType: "string")]
            public string LedgerForAccruedLoanCommissionBusinessLoans { get; set; }
            [ConfigParam(name: "LedgerForRecoveryOfBadDebts", description: "Ledger account for recovery of bad debts", paramType: "string")]
            public string LedgerForRecoveryOfBadDebts { get; set; }
            [ConfigParam(name: "LedgerForLoanCheques", description: "Ledger account for loan related cheques", paramType: "string")]
            public string LedgerForLoanCheques { get; set; }
            [ConfigParam(name: "LedgerForCurrencyDifferences", description: "Ledger account for loan currency difference", paramType: "string")]
            public string LedgerForCurrencyDifferences { get; set; }
            [ConfigParam(name: "LedgerForLoanOverPayments", description: "Ledger account for loan over payment", paramType: "string")]
            public string LedgerForLoanOverPayments { get; set; }
            [ConfigParam(name: "LedgerForSupplierLoanMarkUp", description: "Ledger account supplier loans markup", paramType: "string")]
            public string LedgerForSupplierLoanMarkUp { get; set; }
            [ConfigParam(name: "LedgerForAccruedLoanChargesPersonalLoans", description: "Ledger account for accrued loan charges on personal loans", paramType: "string")]
            public string LedgerForAccruedLoanChargesPersonalLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedLoanChargesGroupLoans", description: "Ledger account for accrued loan charges on group loans", paramType: "string")]
            public string LedgerForAccruedLoanChargesGroupLoans { get; set; }
            [ConfigParam(name: "LedgerForAccruedLoanChargesBusinessLoans", description: "Ledger account for accrued loan charges on business loans", paramType: "string")]
            public string LedgerForAccruedLoanChargesBusinessLoans { get; set; }

            [ConfigParam(name: "TurnOnSendSmsBeforeFirstDuedate", description: "Check whether sending the first SMS before due date is turned on", paramType: "bool")]
            public string TurnOnSendSmsBeforeFirstDuedate { get; set; }
            [ConfigParam(name: "DaysToSendSmsBeforeFirstDuedate", description: "Number of days that are left before due date to send first SMS", paramType: "int")]
            public string DaysToSendSmsBeforeFirstDuedate { get; set; }
            [ConfigParam(name: "TurnOnSendSmsBeforeSecondDuedate", description: "Check whether sending the second SMS before due date is turned on", paramType: "bool")]
            public string TurnOnSendSmsBeforeSecondDuedate { get; set; }
            [ConfigParam(name: "DaysToSendSmsBeforeSecondDuedate", description: "Number of days that are left before due date to send second SMS", paramType: "int")]
            public string DaysToSendSmsBeforeSecondDuedate { get; set; }
            [ConfigParam(name: "TurnOnSendSmsBeforeThirdDuedate", description: "Check whether sending the third SMS before due date is turned on", paramType: "bool")]
            public string TurnOnSendSmsBeforeThirdDuedate { get; set; }
            [ConfigParam(name: "DaysToSendSmsBeforeThirdDuedate", description: "Number of days that are left before due date to send third SMS", paramType: "int")]
            public string DaysToSendSmsBeforeThirdDuedate { get; set; }
            [ConfigParam(name: "TurnOnSendSmsAfterFirstDuedate", description: "Check whether sending the first SMS after due date is turned on", paramType: "bool")]
            public string TurnOnSendSmsAfterFirstDuedate { get; set; }
            [ConfigParam(name: "DaysToSendSmsAfterFirstDuedate", description: "Number of days that are passed after due date to send first SMS", paramType: "int")]
            public string DaysToSendSmsAfterFirstDuedate { get; set; }
            [ConfigParam(name: "TurnOnSendSmsAfterSecondDuedate", description: "Check whether sending the second SMS after due date is turned on", paramType: "bool")]
            public string TurnOnSendSmsAfterSecondDuedate { get; set; }
            [ConfigParam(name: "DaysToSendSmsAfterSecondDuedate", description: "Number of days that are passed after due date to send second SMS", paramType: "int")]
            public string DaysToSendSmsAfterSecondDuedate { get; set; }
            [ConfigParam(name: "TurnOnSendSmsAfterThirdDuedate", description: "Check whether sending the third SMS after due date is turned on", paramType: "bool")]
            public string TurnOnSendSmsAfterThirdDuedate { get; set; }
            [ConfigParam(name: "DaysToSendSmsAfterThirdDuedate", description: "Number of of days that are passed after due date to send third SMS", paramType: "int")]
            public string DaysToSendSmsAfterThirdDuedate { get; set; }
            [ConfigParam(name: "GroupSmsSendingOption", description: "Group SMS sending option eg. To all members or to group management", paramType: "int")]
            public string GroupSmsSendingOption { get; set; }
            [ConfigParam(name: "SmsSendingTime", description: "Group SMS sending time", paramType: "string")]
            public string SmsSendingTime { get; set; }
     }

}
