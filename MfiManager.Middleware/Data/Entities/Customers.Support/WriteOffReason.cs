namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    /// <summary>
    /// Loan write-off reasons
    /// </summary>
    public class WriteOffReason : ReasonBase {
        public virtual ICollection<WittenOffLoan> Loans {get;set;}=[];
    }
}
