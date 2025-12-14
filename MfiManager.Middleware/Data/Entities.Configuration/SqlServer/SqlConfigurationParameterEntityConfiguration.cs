using MfiManager.Middleware.Data.Entities.System.Configurations.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlConfigurationParameterEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ConfigurationParameter> builder) {
            builder.ToTable("TBL_MFI_CONFIG_PARAM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ParameterName).HasColumnName("param_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.ParameterValue).HasColumnName("param_value").HasColumnType("NVARCHAR(150)").IsRequired();
            builder.Property(p => p.ParamType).HasColumnName("param_type").HasColumnType("NVARCHAR(20)").IsRequired();
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Branch).WithMany(bc => bc.ConfigurationParameters).HasForeignKey(bc => bc.BranchId);
        }
    }

}
