using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlProductTypeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ProductType> builder) {
             builder.ToTable("TBL_MFI_PRODUCT_TYPE");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("type_code").HasColumnType("NVARCHAR(200)");
             builder.Property(p => p.Name).HasColumnName("type_name").HasColumnType("NVARCHAR(MAX)");
             builder.Property(p => p.Series).HasColumnName("type_series");
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasMany(m => m.TimedepositProducts).WithOne(o => o.ProductType).HasForeignKey(mp => mp.ProductTypeId);
             builder.HasMany(m => m.ShareProducts).WithOne(o => o.ProductType).HasForeignKey(mp => mp.ProductTypeId);
             builder.HasMany(m => m.SavingProducts).WithOne(o => o.ProductType).HasForeignKey(mp => mp.ProductTypeId);
             builder.HasMany(m => m.InsuranceProducts).WithOne(o => o.ProductType).HasForeignKey(mp => mp.ProductTypeId);
             builder.HasMany(m => m.LoanProducts).WithOne(o => o.ProductType).HasForeignKey(mp => mp.ProductTypeId);
        }
    }
}
