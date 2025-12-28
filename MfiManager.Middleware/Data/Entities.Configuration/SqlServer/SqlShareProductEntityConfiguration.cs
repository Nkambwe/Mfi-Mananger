using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlShareProductEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ShareProduct> builder) {
            builder.ToTable("TBL_MFI_SHARE_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("product_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ProductName).HasColumnName("product_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.IsActive).HasColumnName("is_active");
            builder.Property(p => p.VatInclusive).HasColumnName("vat_inclusive");
            builder.Property(p => p.UseChargeGroups).HasColumnName("use_charge_groups");
            builder.Property(p => p.ProductTypeId).HasColumnName("product_type_id");
            builder.Property(p => p.ChargeGroupId).HasColumnName("charge_group_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ProductType).WithMany(o => o.ShareProducts).HasForeignKey(mp => mp.ProductTypeId);
            builder.HasOne(m => m.ChargeGroup).WithMany(o => o.ShareProducts).HasForeignKey(mp => mp.ChargeGroupId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.ShareProduct).HasForeignKey(mp => mp.ShareProductId);
            builder.HasMany(m => m.TaxableItems).WithOne(o => o.ShareProduct).HasForeignKey(mp => mp.ShareProductId);
            builder.HasMany(m => m.ProductParams).WithOne(o => o.ShareProduct).HasForeignKey(mp => mp.ShareProductId);
            builder.HasMany(m => m.ShareAccounts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ShareValues).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
