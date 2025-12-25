using MfiManager.Middleware.Data.Entities.Audits;
using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.Operations.Products;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Client loan record
    /// </summary>
    public class LoanRecord : BaseEntity {
        public string LoanNumber { get; set; }
        public decimal InterestRate { get; set; }
        public int Installments { get; set; }
        public decimal Principal { get; set; }
        public decimal Interest { get; set; }
        public DateTime ApplicationDate { get; set; }
        /// <summary>
        /// Get/Set loan assessment date
        /// </summary>
        public DateTime? AssesementDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Get/Set approval state. ClientApproval state can be Nap, First, Second, Approved
        /// </summary>
        public ApprovalLevel ApprovalLevel { get; set; }
        public bool IsRescheduled { get; set; }
        public LoanStatus LoanStatus { get; set; }
        public bool IsFrozeen { get; set; }
        public long ProductId { get; set; }
        public virtual LoanProduct Product { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public long CreditOfficerId { get; set; }
        public virtual LoanOfficer CreditOfficer { get; set; }
        public long? PersonId { get; set; }
        public virtual Individual Individual {get;set;}
        public long? BusinessId { get; set; }
        public virtual Business Business {get;set;}
        public long? MemberId { get; set; }
        public virtual Member Member {get;set;}
        public long? GroupId { get; set; }
        public virtual Group Group {get;set;}
        public long? CycleId { get; set; }
        public virtual LoanCycle Cycle { get; set; }
        public long? Filter1Id { get; set; }
        public virtual LoanFilter1 Filter1 { get; set; }
        public long? Filter2Id { get; set; }
        public virtual LoanFilter2 Filter2 { get; set; }
        public long? Filter3Id { get; set; }
        public virtual LoanFilter3 Filter3 { get; set; }
        public long? Filter4Id { get; set; }
        public virtual LoanFilter4 Filter4 { get; set; }
        public long? PurposeId { get; set; }
        public virtual Purpose Purpose { get; set; }
        public long? FundId { get; set; }
        public virtual RevolvingFund RevolvingFund { get; set; }
        public virtual ICollection<AmortizedDue> Amortization { get; set; } = [];
        public virtual ICollection<ApprovedAmount> ApprovedAmounts { get; set; } = [];
        public virtual ICollection<ApplicationNotes> ApprovalNotes { get; set; } = [];
        public virtual ICollection<Disbursement> Disbursements { get; set; } = [];
        public virtual ICollection<DefferedLoan> DefferedLoans { get; set; } = [];
        public virtual ICollection<LoanDeclassified> DeclassifiedLoans { get; set; } = [];
        public virtual ICollection<ExpectedDisbursement> ExpectedDisbursements { get; set; } = [];
        public virtual ICollection<LoanFreez> LoanFreez { get; set; } = [];
        public virtual ICollection<LoanApproval> LoanApprovals { get; set; } = [];
        public virtual ICollection<GroupLoanBreakdown> GroupLoanBreakdowns { get; set; } = [];
        public virtual ICollection<LoanCollateral> Collaterals { get; set; } = [];
        public virtual ICollection<LoanDue> LoanDues { get; set; } = [];
        public virtual ICollection<LoanGuarantor> Guarantors { get; set; } = [];
        public virtual ICollection<LoanLossProvision> LossProvisions { get; set; } = [];
        public virtual ICollection<RepaymentLedger> RepaymentTransactions { get; set; } = [];
        public ICollection<RejectedLoan> RejectedLoans { get; set; } = [];
        public virtual ICollection<LoanTransfer> Transfers { get; set; } = [];
        public ICollection<ModifiedLoan> Modifications { get; set; } = [];
        public ICollection<WittenOffLoan> WittenOffLoans { get; set; } = [];
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
