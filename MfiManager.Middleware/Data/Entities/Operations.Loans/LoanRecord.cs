using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Client loan record
    /// </summary>
    public class LoanRecord : BaseEntity {
        public long? ClientId { get; set; }
        public string Branch { get; set; }
        public string Membership { get; set; }
        public string LoanNumber { get; set; }
        public long ProductId { get; set; }
        public long? FundId { get; set; }
        public DateTime AppliedOn { get; set; }
        /// <summary>
        /// Get/Set loan assessment date
        /// </summary>
        public DateTime? AssessedOn { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public decimal Rate { get; set; }
        public int Installments { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }

        /// <summary>
        /// Get/Set approval state. ClientApproval state can be Nap, First, Second, Approved
        /// </summary>
        public ApprovalState Approval { get; set; }
        public bool Rescheduled { get; set; }
        public LoanStatus Status { get; set; }
        public string CreditOfficer { get; set; }
        public long? CycleId { get; set; }
        public long? PurposeId { get; set; }
        public long? Custome1Id { get; set; }
        public long? Custome2Id { get; set; }
        public long? Custome3Id { get; set; }
        public long? Custome4Id { get; set; }
        public bool IsFrozeen { get; set; }
        public virtual LoanCycle Cycle { get; set; }
        public virtual Purpose Purpose { get; set; }
        public virtual RevolvingFund RevolvingFund { get; set; }
        public virtual LoanProduct Product { get; set; }
        public virtual LoanCustomeProperty1 Custome1 { get; set; }
        public virtual LoanCustomeProperty2 Custome2 { get; set; }
        public virtual LoanCustomeProperty3 Custome3 { get; set; }
        public virtual LoanCustomeProperty4 Custome4 { get; set; }
        public virtual ICollection<Frozen> Freezes { get; set; } = [];
        public ICollection<ModifiedLoan> Modifications { get; set; } = [];
        public virtual ICollection<ApplicationNotes> Notes { get; set; } = [];
        public virtual ICollection<Guarantor> Guarantors { get; set; } = [];
        public virtual ICollection<DeclassifiedLoan> DeclassifiedLoans { get; set; } = [];
        public virtual ICollection<LossProvision> Provisions { get; set; } = [];
        public virtual ICollection<DefferedLoan> DefferedLoans { get; set; } = [];
        public virtual ICollection<ApprovedAmount> ApprovedAmounts { get; set; } = [];
        public virtual ICollection<LoanApproval> Approvals { get; set; } = [];
        public virtual ICollection<ExpectedDisbursement> ExpectedDisbursements { get; set; } = [];
        public virtual ICollection<AmortizedDue> Amortization { get; set; } = [];
        public virtual ICollection<LoanDue> Dues { get; set; } = [];
        public virtual ICollection<RepaymentTransaction> Repayments { get; set; } = [];
        public virtual ICollection<Disbursement> Disbursements { get; set; } = [];
        public virtual ICollection<LoanTransfer> Transfers { get; set; } = [];
        public virtual ICollection<LoanBreakdown> Breakdowns { get; set; } = [];

        public override string ToString() => $"{(string.IsNullOrEmpty(LoanNumber) ? "000000" : LoanNumber.Trim())}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;

        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherLoan"/>Object to compare to this  <see cref="LoanRecord"/>
        /// <returns>
        /// True if object is the same as this <see cref="LoanRecord"/>, false otherwise.
        /// </returns>
        public override bool Equals(object otherLoan) {

            if (otherLoan == null || otherLoan.GetType() != typeof(LoanRecord)) return false;

            if (ReferenceEquals(this, otherLoan)) return true;

            var loan = otherLoan as LoanRecord;
            return loan != null && loan.LoanNumber.Trim().Equals(LoanNumber.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two instances of <see cref="LoanRecord"/> objects for equality.
        /// </summary>
        /// <param name="thisLoan">The First <see cref="LoanRecord"/> instance to compare.</param>
        /// <param name="thatLoan">The second <see cref="LoanRecord"/> instance to compare.</param>
        /// <returns>
        /// True when the loans are the same, false otherwise.
        /// </returns>
        public static bool operator ==(LoanRecord thisLoan, LoanRecord thatLoan)
            => thatLoan?.Equals(thisLoan) ?? Equals(thisLoan, null);

        /// <summary>
        /// Compares two instances of <see cref="LoanRecord"/> objects for inequality.
        /// </summary>
        /// <param name="thisLoan">The First <see cref="LoanRecord"/> instance to compare.</param>
        /// <param name="thatLoan">The second <see cref="LoanRecord"/> instance to compare.</param>
        /// <returns>
        /// False when the loans are the same, true otherwise.
        /// </returns>
        public static bool operator !=(LoanRecord thisLoan, LoanRecord thatLoan)
            => !(thatLoan == thisLoan);
    }
}
