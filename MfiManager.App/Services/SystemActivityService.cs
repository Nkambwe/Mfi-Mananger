using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;

namespace MfiManager.App.Services {
    public class SystemActivityService : ISystemActivityService {
        public Task<MfiHttpResponse<PagedResponse<ActivityResponse>>> GetActivityLogsAsync(MfiHttpListRequest request) {
            throw new NotImplementedException();
        }

        public Task<MfiHttpResponse<MfiHttpStatusResponse>> InsertActivityAsync(long userId, string activity, string comment, string systemKeyword = null, string entityName = null, string ipAddress = null) {
            throw new NotImplementedException();
        }
    }
}
