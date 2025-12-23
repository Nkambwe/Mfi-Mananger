namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Loan write-off reasons
    /// </summary>
    public class WriteOffReason : ReasonBase {
        public virtual ICollection<WittenOffLoan> Loans { get; set; } = [];
    }
}
