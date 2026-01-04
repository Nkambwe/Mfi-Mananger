using MfiManager.Middleware.Data.Entities.Operations.Saving;

namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {
    /// <summary>
    /// Reason for freezing loans
    /// </summary>
    public class AccountFreezeReason : ReasonBase {
        public virtual ICollection<FrozenAccount> FrozenAccounts { get; set; }
    }
}
