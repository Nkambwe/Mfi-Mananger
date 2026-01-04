namespace MfiManager.Middleware.Security {
    public class RequestContext : IRequestContext {
        public long CompanyId { get; set; }
        public long BranchId { get; set; }
    }
}
