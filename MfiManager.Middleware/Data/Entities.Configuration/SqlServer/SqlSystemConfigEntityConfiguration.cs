using MfiManager.Middleware.Data.Entities.System.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSystemConfigEntityConfiguration {
        public static void Configure(EntityTypeBuilder<SystemConfiguration> builder) {
            builder.ToTable("TBL_MFI_SYS_CONFIG"); 
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnName("id");
            builder.Property(f => f.CompanyId).HasColumnName("company_id").IsRequired(false);
            builder.Property(f => f.BranchId).HasColumnName("branch_id").IsRequired(false);
            builder.Property(f => f.ParameterName).HasColumnName("parameter_name").HasColumnType("NVARCHAR(100)").IsRequired();
            builder.Property(f => f.ParameterValue).HasColumnName("parameter_value").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(f => f.Description).HasColumnName("param_description").HasColumnType("NVARCHAR(500)").IsRequired(false);
            builder.Property(f => f.IsDeleted).HasColumnName("is_deleted");
            builder.Property(f => f.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(f => f.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(f => f.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(f => f.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(f => f.Branch).WithMany(b => b.Configurations).HasForeignKey(f => f.BranchId);
            builder.HasOne(f => f.Company).WithMany(c => c.SystemConfigurations).HasForeignKey(f => f.CompanyId);
        }
    }

}
