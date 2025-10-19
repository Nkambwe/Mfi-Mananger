using MfiManager.App.Http.Requests;
using MfiManager.App.Models;

namespace MfiManager.App.Infrastructure.Utils {
    public static class Mapper {

        public static SystemErrorRequest ToSystemErrorRequest(MfiErrorModel model, string ipAddress)
            => new(){ 
                CompanyId = model.CompanyId,
                UserId = model.UserId,
                IPAddress = ipAddress,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace
            };

        public static MfiErrorModel ToMfiErrorModel(SystemErrorRequest request)
             => new(){ 
                CompanyId = request.CompanyId,
                UserId = request.UserId,
                Source = request.Source,
                Message = request.Message,
                Severity = request.Severity,
                StackTrace = request.StackTrace
            };

    }
}
