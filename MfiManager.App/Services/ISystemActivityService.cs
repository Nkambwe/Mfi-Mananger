using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;

namespace MfiManager.App.Services {
    public interface ISystemActivityService {

        Task<MfiHttpResponse<PagedResponse<ActivityResponse>>> GetActivityLogsAsync(MfiHttpListRequest request);
        Task<MfiHttpResponse<MfiHttpStatusResponse>> InsertActivityAsync(long userId, string activity, string comment, string systemKeyword=null, string entityName=null, string ipAddress = null);
    }
}
