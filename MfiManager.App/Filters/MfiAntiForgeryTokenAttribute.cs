using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace MfiManager.App.Filters {
    public class MfiAntiForgeryTokenAttribute(IAntiforgery antiforgery) : ActionFilterAttribute, IAuthorizationFilter {
        
        private readonly IAntiforgery _antiforgery = antiforgery;

        public void OnAuthorization(AuthorizationFilterContext context) {
            if (context.HttpContext.Request.Method == "POST" || 
                context.HttpContext.Request.Method == "PUT" || 
                context.HttpContext.Request.Method == "DELETE") {
                try {
                    _antiforgery.ValidateRequestAsync(context.HttpContext).Wait();
                } catch (AntiforgeryValidationException) {
                    context.Result = new BadRequestResult();
                }
            }
        }
    }
}
