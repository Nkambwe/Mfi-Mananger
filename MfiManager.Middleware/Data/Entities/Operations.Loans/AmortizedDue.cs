namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Dues generated at disbursement
    /// </summary>
    public class AmortizedDue : DueBase {
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
