using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Http.Requests;
using MfiManager.Middleware.Http.Responses;

namespace MfiManager.Middleware.Utils {
    public static class Mapper {

        public static SystemError ToSystemErrorRequest(AppErrorRequest model)
            => new(){ 
                CompanyId = model.CompanyId,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace
            };

         public static AppErrorResponse ToSystemErrorRequest(SystemError model)
            => new(){ 
                Id = model.Id,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace,
                IsDeleted = model.IsDeleted,
                Status = model.Status,
                CreatedOn = model.CreatedOn
            };
    }
}
