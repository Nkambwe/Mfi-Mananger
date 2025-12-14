namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    public class LoanApproval : BaseEntity {
        public long? LoanId { get; set; }
        public bool First { get; set; }
        public DateTime? FirstApproval { get; set; }
        public string FirstOfficer { get; set; }
        public string FirstApprovalNotes { get; set; }
        public bool Second { get; set; }
        public DateTime? SecondtApproval { get; set; }
        public string SecondOfficer { get; set; }
        public string SecondApprovalNotes { get; set; }
        public bool Third { get; set; }
        public DateTime? ThirdApproval { get; set; }
        public string ThirdOfficer { get; set; }
        public string ThirdApprovalNotes { get; set; }
        public virtual LoanRecord Loan { get; set; }
    }
}
