using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan that are at risk of default. Declassified loans have unpaid interest and principal outstanding, but don't necessarily need to be past due. 
    /// If a declassified loan starts missing payments (usually 90 days past due), then its status can be changed to classified if the loan is deemed irredemable
    /// (doubtful or loss). Loans are declassified based on days in arrears and other risk factors
    /// </summary>
    /// <remarks>
    /// Loan that is in high risk of default are called classified loans and will be classified as doubtfull or
    /// as loss. Once a loan is classified, the borrower can take steps to prepare for losses it expects from non-payment
    /// </remarks>
    public class DeclassifiedLoan : BaseEntity {
        public long LoanId { get; set; }
        public Classification Classification { get; set; }
        public virtual LoanRecord Loan { get; set; }

    }
}
