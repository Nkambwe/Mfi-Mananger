
using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Services {

    public interface ISystemErrorService: IBaseService {
        Task<Company> GetDefaultCompanyAsync();
    }

}
