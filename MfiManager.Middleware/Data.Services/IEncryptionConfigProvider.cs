using MfiManager.Middleware.Security;

namespace MfiManager.Middleware.Data.Services {
    public interface IEncryptionConfigProvider {
        EncryptionConfig GetConfig(long companyId, long branchId);
    }


}
