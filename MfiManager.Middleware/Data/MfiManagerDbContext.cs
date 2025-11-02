using MfiManager.Middleware.Data.Entities.Configuration.Oracle;
using MfiManager.Middleware.Data.Entities.Configuration.PostgreSql;
using MfiManager.Middleware.Data.Entities.Configuration.SqlServer;
using MfiManager.Middleware.Data.Entities.System;
using Microsoft.EntityFrameworkCore;

namespace MfiManager.Middleware.Data {

    public class MfiManagerDbContext(DbContextOptions<MfiManagerDbContext> options) : DbContext(options) {
        public DbSet<Company> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentUnit> DepartmentUnits { get; set; }
        public DbSet<SystemError> SystemErrors { get; set; }
        public DbSet<RoleGroup> RoleGroups { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<LoginAttempt> Attempts { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserActivityLog> ActivityLogs { get; set; }
        public DbSet<UserQuickAction> QuickActions { get; set; }
        public DbSet<MfiEntity> SystemEntities { get; set; }
        public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            var provider = Database.ProviderName ?? string.Empty;
            if (provider.Contains("SqlServer", StringComparison.OrdinalIgnoreCase))
                ConfigureSqlServer(modelBuilder);
            else if (provider.Contains("Npgsql", StringComparison.OrdinalIgnoreCase))
                ConfigurePostgreSql(modelBuilder);
            else if (provider.Contains("Oracle", StringComparison.OrdinalIgnoreCase))
                ConfigureOracle(modelBuilder);
        }

        private static void ConfigureOracle(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("MFI_APP");
            modelBuilder.HasSequence<long>("ACTIVITYLOG_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("BRANCH_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("COMPANY_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("DEPARTMENT_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("DEPARTMENTUNIT_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ENTITY_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ERROR_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ACTION_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ROLE_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ROLEGROUP_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("CONFIG_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("ACTIVITY_SEQ").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("USER_SEQ").StartsAt(1).IncrementsBy(1);

            OracleActivityLogEntityConfiguration.Configure(modelBuilder.Entity<UserActivityLog>());
            OracleBranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            OracleCompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            OracleDepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            OracleDeptUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            OracleEntityEntityConfiguration.Configure(modelBuilder.Entity<MfiEntity>());
            OracleErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
            OracleLoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            OracleQuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());
            OracleRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            OracleRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<RoleGroup>());
            OracleSystemConfigEntityConfiguration.Configure(modelBuilder.Entity<SystemConfiguration>());
            OracleUserActivityEntityConfiguration.Configure(modelBuilder.Entity<UserActivity>());
            OracleUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());
        }

        private static void ConfigurePostgreSql(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.HasSequence<long>("activitylog_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("branch_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("company_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("department_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("departmentunit_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("mfientity_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("Systemerror_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("loginattempt_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("quickaction_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("role_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("rolegroup_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("Sysconfig_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("activity_seq").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<long>("Systemuser_seq").StartsAt(1).IncrementsBy(1);

            PsqlActivityLogEntityConfiguration.Configure(modelBuilder.Entity<UserActivityLog>());
            PsqlBranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            PsqlCompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            PsqlDepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            PsqlDeptUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            PsqlEntityEntityConfiguration.Configure(modelBuilder.Entity<MfiEntity>());
            PsqlErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
            PsqlLoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            PsqlQuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());
            PsqlRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            PsqlRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<RoleGroup>());
            PsqlSystemConfigEntityConfiguration.Configure(modelBuilder.Entity<SystemConfiguration>());
            PsqlUserActivityEntityConfiguration.Configure(modelBuilder.Entity<UserActivity>());
            PsqlUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());

        }

        private static void ConfigureSqlServer(ModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("dbo");
            SqlCompanyEntityConfiguration.Configure(modelBuilder.Entity<Company>());
            SqlBranchEntityConfiguration.Configure(modelBuilder.Entity<Branch>());
            SqlDepartmentEntityConfiguration.Configure(modelBuilder.Entity<Department>());
            SqlDeptUnitEntityConfiguration.Configure(modelBuilder.Entity<DepartmentUnit>());
            SqlUserEntityConfiguration.Configure(modelBuilder.Entity<SystemUser>());
            SqlRoleEntityConfiguration.Configure(modelBuilder.Entity<SystemRole>());
            SqlRoleGroupEntityConfiguration.Configure(modelBuilder.Entity<RoleGroup>());
            SqlLoginAttemptEntityConfiguration.Configure(modelBuilder.Entity<LoginAttempt>());
            SqlQuickActionEntityConfiguration.Configure(modelBuilder.Entity<UserQuickAction>());
            SqlUserActivityEntityConfiguration.Configure(modelBuilder.Entity<UserActivity>());
            SqlActivityLogEntityConfiguration.Configure(modelBuilder.Entity<UserActivityLog>());
            SqlEntityEntityConfiguration.Configure(modelBuilder.Entity<MfiEntity>());
            SqlSystemConfigEntityConfiguration.Configure(modelBuilder.Entity<SystemConfiguration>());
            SqlErrorEntityConfiguration.Configure(modelBuilder.Entity<SystemError>());
        }
    }

}
