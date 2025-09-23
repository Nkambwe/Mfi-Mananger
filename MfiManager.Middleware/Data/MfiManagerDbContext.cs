using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Data {

    public class MfiManagerDbContext(DbContextOptions<MfiManagerDbContext> options) : DbContext(options) {
        //public DbSet<Company> Organizations { get; set; }
        //public DbSet<Branch> Branches { get; set; }
        //public DbSet<SystemError> SystemErrors { get; set; }
        //public DbSet<ActivityLog> ActivityLogs { get; set; }
        //public DbSet<ActivityType> ActivityTypes { get; set; }
        //public DbSet<ActivityLogSetting> ActivitySettings { get; set; }
        //public DbSet<Department> Departments { get; set; }
        //public DbSet<DepartmentUnit> DepartmentUnits { get; set; }
        //public DbSet<SystemRoleGroup> RoleGroups { get; set; }
        //public DbSet<SystemRole> SystemRoles { get; set; }
        //public DbSet<SystemUser> SystemUsers { get; set; }
        //public DbSet<LoginAttempt> Attempts { get; set; }
        //public DbSet<UserQuickAction> QuickActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //CompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            //BranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            //SystemErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
            //ActivityLogSettingEntityConfiguration.Configure(modelBuilder.Entity<ActivityLogSetting>());
            //ActivityTypeEntityConfiguration.Configure(modelBuilder.Entity<ActivityType>());
            //ActivityLogEntityConfiguration.Configure(modelBuilder.Entity<ActivityLog>());
            //DepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            //DepartmentUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            //SystemRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<SystemRoleGroup>());
            //SystemRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            //SystemUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());
            //LoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            //QuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());

            base.OnModelCreating(modelBuilder);
        }

    }

}
