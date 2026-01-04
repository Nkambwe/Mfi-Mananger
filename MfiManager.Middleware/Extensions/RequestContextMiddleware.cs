using MfiManager.Middleware.Security;

namespace MfiManager.Middleware.Extensions {
    public class RequestContextMiddleware(RequestDelegate next) {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext context, IRequestContext requestContext){
            requestContext.CompanyId = long.Parse(context.User.FindFirst("CompanyId")!.Value);
            requestContext.BranchId = long.Parse(context.User.FindFirst("BranchId")!.Value);
            await _next(context);
        }
    }
}
