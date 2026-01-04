using MfiManager.Middleware.Http.Responses;

namespace MfiManager.Middleware.Data.Services {

    public interface IEntityMetadataService {
        IEnumerable<EncryptableFieldResponse> GetEncryptableFields(string entityName);
    }

}
