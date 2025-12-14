using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTaxableItemEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TaxableItem> builder) {
            builder.ToTable("TBL_MFI_TAXABLE_ITEM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ItemCode).HasColumnName("item_code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Item).HasColumnName("item_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Suspend).HasColumnName("is_suspended");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted").IsRequired(false);
            builder.Property(p => p.Started).HasColumnName("start_date").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.TaxId).HasColumnName("tax_id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Tax).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.TaxId);
            builder.HasOne(m => m.Product).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.TaxId);
        }
    }
}
