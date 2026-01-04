namespace MfiManager.Middleware.Security {
    public interface IRequestContext {
        long CompanyId { get; set;}
        long BranchId { get; set;}
    }
}
