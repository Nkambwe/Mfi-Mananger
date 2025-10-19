using MfiManager.App.Models;
using Microsoft.AspNetCore.Diagnostics;
using System.Reflection;

namespace MfiManager.App.Factories {
    public class ViewErrorFactory : IViewErrorFactory {
        public Task<ErrorViewModel> Prepare401ErrorViewModelAsync(bool isLive, HttpContext context) {
            var model = new ErrorViewModel { IsLive = isLive };
            var statusCodeFeature = context.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeFeature != null)
            {
                model.StatusCode = 401;
                model.OriginalPath = statusCodeFeature.OriginalPath;
                model.OriginalQueryString = statusCodeFeature.OriginalQueryString;
                model.ErrorMessage = "Your profile is not authorized to access this resource";
            }

            return Task.FromResult(model);
           
        }

        public Task<ErrorViewModel> Prepare403ErrorViewModelAsync(bool isLive, HttpContext context) {
            var model = new ErrorViewModel { IsLive = isLive };
            var statusCodeFeature = context.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeFeature != null) {
                model.StatusCode = 403;
                 model.OriginalPath = statusCodeFeature.OriginalPath;
                 model.OriginalQueryString = statusCodeFeature.OriginalQueryString;
                 model.ErrorMessage = "Access Denied! Access to this resource is forbidden";
            }
            return Task.FromResult(model);
           
        }

        public Task<ErrorViewModel> Prepare404ErrorViewModelAsync(bool isLive, HttpContext context) {
            var model = new ErrorViewModel { IsLive = isLive };
            var statusCodeFeature = context.Features.Get<IStatusCodeReExecuteFeature>();
            if (statusCodeFeature != null) {
                model.StatusCode = 404;
                model.OriginalPath = statusCodeFeature.OriginalPath;
                model.OriginalQueryString = statusCodeFeature.OriginalQueryString;
                model.ErrorMessage = "Resource not found";
            }
            
            return Task.FromResult(model);
        }

        public Task<ErrorViewModel> Prepare500ErrorViewModelAsync(bool isLive, HttpContext context) {
            var model = new ErrorViewModel { IsLive = isLive };

            if (!isLive) {
                var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                if (exceptionFeature != null) {
                    model.StatusCode = 500;
                    model.ErrorMessage = exceptionFeature.Error.Message;
                    model.ErrorPath = exceptionFeature.Path;
                    model.StackTrace = exceptionFeature.Error.StackTrace;
                }

            }

            return Task.FromResult(model);
        }

        public Task<ErrorViewModel> Prepare503ErrorViewModelAsync(bool isLive, HttpContext context) {
            var model = new ErrorViewModel { IsLive = isLive };
            var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionFeature != null) {
                model.StatusCode = 503;
                model.ErrorMessage = "Service Unavailable! The server is currently unable to handle the request due to a temporary overloading or maintenance of the server. Please try again later.";
            }

            return Task.FromResult(model);
        }

    }
}
