using MfiManager.Middleware.Data.Entities;
using MfiManager.Middleware.Data.Transaction.Repositories;

namespace MfiManager.Middleware.Data.Transaction {

    public interface IUnitOfWork : IDisposable {

        public MfiManagerDbContext Context { get;} 
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        //public ICompanyRepository CompanyRepository { get; set;}
        //public IBranchRepository BranchRepository { get; set;}
        //public IUserRepository UserRepository { get; set;}
        //public IRoleRepository RoleRepository { get; set; }
        //public IRoleGroupRepository RoleGroupRepository { get; set; }
        //public IUserViewRepository UserViewRepository{get; set;}
        //public IUserPreferenceRepository UserPreferenceRepository { get; set;}
        //public IAttemptRepository AttemptRepository { get; set; }
        //public IQuickActionRepository QuickActionRepository { get; set; }
        //public IPinnedItemRepository PinnedItemRepository { get; set; }
        //public ISystemErrorRespository SystemErrorRespository { get; set; }
        //public IActivityTypeRepository ActivityTypeRepository { get; set; }
        //public IActivityLogRepository ActivityLogRepository { get; set; }
        //public IActivityLogSettingRepository ActivityLogSettingRepository { get; set; }
        //public IDepartmentRepository DepartmentRepository { get; set; }
        //public IDepartmentUnitRepository DepartmentUnitRepository { get; set; }

        public Task<int> SaveChangesAsync(); 
        public int SaveChanges(); 
    }
}
