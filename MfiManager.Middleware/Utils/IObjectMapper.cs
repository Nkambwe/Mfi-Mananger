using MfiManager.Middleware.Data.Entities.Customers;
using MfiManager.Middleware.Http.Responses;
using MfiManager.Middleware.Security;

namespace MfiManager.Middleware.Utils {
    public interface IObjectMapper {
        IndividualResponse Map(Individual record, EncryptionConfig config);
    }

}
