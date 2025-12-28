using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Products;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    public class GroupLoan: LoanBase {
        public long ProductId { get; set; }
        public virtual LoanProduct Product { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public long CreditOfficerId { get; set; }
        public virtual LoanOfficer CreditOfficer { get; set; }
        public long? Filter1Id { get; set; }
        public virtual LoanFilter1 Filter1 { get; set; }
        public long? Filter2Id { get; set; }
        public virtual LoanFilter2 Filter2 { get; set; }
        public long? Filter3Id { get; set; }
        public virtual LoanFilter3 Filter3 { get; set; }
        public long? Filter4Id { get; set; }
        public virtual LoanFilter4 Filter4 { get; set; }
        public long? PurposeId { get; set; }
        public virtual LoanPurpose Purpose { get; set; }
        public long? FundId { get; set; }
        public virtual RevolvingFund RevolvingFund { get; set; }
        public long LoanAccountId { get; set; }
        public virtual GroupLoanAccount LoanAccount { get; set; }
        public virtual ICollection<AmortizedDue> Amortization { get; set; } = [];
        public virtual ICollection<LoanApprovedAmount> ApprovedAmounts { get; set; } = [];
        public virtual ICollection<ApplicationNotes> ApprovalNotes { get; set; } = [];
        public virtual ICollection<Disbursement> Disbursements { get; set; } = [];
        public virtual ICollection<DefferedLoan> DefferedLoans { get; set; } = [];
        public virtual ICollection<LoanDeclassified> DeclassifiedLoans { get; set; } = [];
        public virtual ICollection<ExpectedDisbursement> ExpectedDisbursements { get; set; } = [];
        public virtual ICollection<LoanFreez> LoanFreez { get; set; } = [];
        public virtual ICollection<LoanApproval> LoanApprovals { get; set; } = [];
        public virtual ICollection<GroupLoanCollateral> Collaterals { get; set; } = [];
        public virtual ICollection<LoanDue> LoanDues { get; set; } = [];
        public virtual ICollection<GroupLoanGuarantor> Guarantors { get; set; } = [];
        public virtual ICollection<LoanLossProvision> LossProvisions { get; set; } = [];
        public virtual ICollection<RepaymentLedger> RepaymentTransactions { get; set; } = [];
        public ICollection<RejectedLoan> Rejects { get; set; } = [];
        public virtual ICollection<LoanTransfer> Transfers { get; set; } = [];
        public ICollection<ModifiedLoan> Modifications { get; set; } = [];
        public ICollection<WittenOffLoan> WittenOffLoans { get; set; } = [];
        public override string ToString() => $"{(string.IsNullOrEmpty(LoanNumber) ? "000000" : LoanNumber.Trim())}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherLoan"/>Object to compare to this  <see cref="GroupLoan"/>
        /// <returns>
        /// True if object is the same as this <see cref="GroupLoan"/>, false otherwise.
        /// </returns>
        public override bool Equals(object otherLoan) {

            if (otherLoan == null || otherLoan.GetType() != typeof(GroupLoan)) return false;

            if (ReferenceEquals(this, otherLoan)) return true;

            var loan = otherLoan as GroupLoan;
            return loan != null && loan.LoanNumber.Trim().Equals(LoanNumber.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares two instances of <see cref="GroupLoan"/> objects for equality.
        /// </summary>
        /// <param name="thisLoan">The First <see cref="GroupLoan"/> instance to compare.</param>
        /// <param name="thatLoan">The second <see cref="GroupLoan"/> instance to compare.</param>
        /// <returns>
        /// True when the loans are the same, false otherwise.
        /// </returns>
        public static bool operator ==(GroupLoan thisLoan, GroupLoan thatLoan)
            => thatLoan?.Equals(thisLoan) ?? Equals(thisLoan, null);

        /// <summary>
        /// Compares two instances of <see cref="GroupLoan"/> objects for inequality.
        /// </summary>
        /// <param name="thisLoan">The First <see cref="GroupLoan"/> instance to compare.</param>
        /// <param name="thatLoan">The second <see cref="GroupLoan"/> instance to compare.</param>
        /// <returns>
        /// False when the loans are the same, true otherwise.
        /// </returns>
        public static bool operator !=(GroupLoan thisLoan, GroupLoan thatLoan)
            => !(thatLoan == thisLoan);
    }

}
