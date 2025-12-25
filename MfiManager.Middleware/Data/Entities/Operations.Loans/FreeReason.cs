namespace MfiManager.Middleware.Data.Entities.Operations.Loans {
    /// <summary>
    /// Reason for freezing loans
    /// </summary>
    public class FreeReason: ReasonBase {
         public virtual ICollection<LoanFreez> LoanFreezes { get; set; }
    }
}
