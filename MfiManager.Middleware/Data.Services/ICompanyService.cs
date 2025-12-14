
using MfiManager.Middleware.Data.Entities.System;

namespace MfiManager.Middleware.Data.Services {
    public interface ICompanyService: IBaseService {
        Task<bool> SaveErrorAsync(SystemError errorObj);
    }
}
