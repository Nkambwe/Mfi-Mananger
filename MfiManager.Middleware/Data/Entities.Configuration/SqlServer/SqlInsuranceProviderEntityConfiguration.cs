using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInsuranceProviderEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Provider> builder) {
            builder.ToTable("TBL_MFI_INSURANCE_PROVIDER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("provider_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("provider_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Active).HasColumnName("is_active");
            builder.Property(p => p.RegisteredOn).HasColumnName("registered_on").IsRequired();
            builder.Property(p => p.ClosedOn).HasColumnName("closed_on").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.Products).WithOne(o => o.Provider).HasForeignKey(mp => mp.ProviderId);
            builder.HasMany(m => m.Policies).WithOne(o => o.Provider).HasForeignKey(mp => mp.ProviderId);
        }
    }

}
