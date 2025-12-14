using MfiManager.Middleware.Data.Entities.Accounts.Charges;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeItemEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ChargeItem> builder) {
            builder.ToTable("TBL_MFI_CHARGE_ITEM");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("charge_code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.ChargeOn).HasColumnName("charge_one");
            builder.Property(p => p.Description).HasColumnName("charge_description").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.FixedAmount).HasColumnName("flat_amount").HasPrecision(19,2);
            builder.Property(p => p.IsRated).HasColumnName("is_rated");
            builder.Property(p => p.Percentage).HasColumnName("per_rate").HasPrecision(19,2);
            builder.Property(p => p.Ledger).HasColumnName("ledger_acc").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.ProductId).HasColumnName("product_id").IsRequired(false);
            builder.Property(p => p.ChargeId).HasColumnName("charge_id");
            builder.Property(p => p.TaxId).HasColumnName("tax_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.ChargedItems).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.Tax).WithMany(o => o.ChargedItems).HasForeignKey(mp => mp.TaxId);
            builder.HasMany(m => m.Charges).WithOne(o => o.ChargeItem).HasForeignKey(mp => mp.ChargeItemId);
            builder.HasMany(m => m.ChargeStages).WithOne(o => o.ChargeItem).HasForeignKey(mp => mp.ChargeItemId);
            builder.HasMany(m => m.ChargeTransactions).WithOne(o => o.ChargeItem).HasForeignKey(mp => mp.ChargeItemId);
        }
    }
}
