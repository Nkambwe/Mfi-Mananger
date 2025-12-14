using MfiManager.Middleware.Data.Entities.System.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlProductConfigurationEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ProductConfiguration> builder) {
            builder.ToTable("TBL_MFI_PRODUCT_CONFIG");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ParameterName).HasColumnName("param_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.ParamValue).HasColumnName("param_value").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.DataType).HasColumnName("data_type").HasColumnType("NVARCHAR(100)");
            builder.Property(p => p.ParamDescription).HasColumnName("param_decription").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.Configurations).HasForeignKey(mp => mp.ProductId);
        }
    }
}
