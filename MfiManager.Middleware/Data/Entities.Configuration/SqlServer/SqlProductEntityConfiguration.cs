using MfiManager.Middleware.Data.Entities.Operations.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlProductEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Product> builder) {
            builder.ToTable("TBL_MFI_PRODUCT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("product_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Name).HasColumnName("product_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.Disabled).HasColumnName("is_disabled");
            builder.Property(p => p.VatInclusive).HasColumnName("vat_inclusive");
            builder.Property(p => p.UseChargeGroups).HasColumnName("use_charge_groups");
            builder.Property(p => p.ProductTypeId).HasColumnName("product_type_id");
            builder.Property(p => p.TaxGroupId).HasColumnName("tax_group_id").IsRequired(false);
            builder.Property(p => p.ChargeGroupId).HasColumnName("charge_group_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ProductType).WithMany(o => o.Products).HasForeignKey(mp => mp.ProductTypeId);
            builder.HasMany(m => m.TaxGroups).WithOne(o => o.Product).HasForeignKey(mp => mp.TaxGroupId);
            builder.HasMany(m => m.TaxableItems).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.Configurations).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.SavingProducts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ShareProducts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.LoanProducts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.InsuranceProducts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.TimedepositProducts).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.Product).HasForeignKey(mp => mp.ProductId);
        }
    }

}
