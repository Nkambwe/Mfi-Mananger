using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlShareProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ShareProduct> builder) {
            builder.ToTable("TBL_MFI_SHARE_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.ShareProducts).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ShareAccounts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ShareValues).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
