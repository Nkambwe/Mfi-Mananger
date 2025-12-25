namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Reason for deferment of a loan
    /// </summary>
    public class DefferReason : ReasonBase {
        public virtual ICollection<DefferedLoan> DefferedLoans { get; set; }
    }
}
