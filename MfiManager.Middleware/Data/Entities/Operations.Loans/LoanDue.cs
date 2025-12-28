namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanDue : DueBase {
        public DateTime DueDate { get; set; }
        public long? IndividualLoanId { get; set; }
        public virtual IndividualLoan IndividualLoan {get;set; }
        public long? GroupLoanId { get; set; }
        public virtual GroupLoan GroupLoan {get;set; }
        public long? BusinessLoanId { get; set; }
        public virtual BusinessLoan BusinessLoan {get;set; }
    }
}
