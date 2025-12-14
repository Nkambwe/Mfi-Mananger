using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPurchaseOrderDefaultEntityConfiguration {

        public static void Configure(EntityTypeBuilder<PurchaseOrderDefault> builder) {
            builder.ToTable("TBL_MFI_PURCHASE_ORDER_DEFAULT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.MultiBranchAccount).HasColumnName("bank_accounts").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.SupplierId).HasColumnName("supplier_id");
            builder.Property(p => p.PriceGroupId).HasColumnName("price_group_id").IsRequired(false);
            builder.Property(p => p.DiscountGroupId).HasColumnName("discount_group_id").IsRequired(false);
            builder.Property(p => p.OrderClassificationId).HasColumnName("order_class_id").IsRequired(false);
            builder.Property(p => p.ItemGroupId).HasColumnName("item_group_id").IsRequired(false);
            builder.Property(p => p.BankAccountId).HasColumnName("bank_account_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Supplier).WithMany(o => o.PurchaseOrderDefaults).HasForeignKey(mp => mp.SupplierId);
            builder.HasOne(m => m.DiscountGroup).WithMany(o => o.PurchaseOrderDefaults).HasForeignKey(mp => mp.DiscountGroupId);
            builder.HasOne(m => m.PriceGroup).WithMany(o => o.PurchaseOrderDefaults).HasForeignKey(mp => mp.PriceGroupId);
            builder.HasOne(m => m.OrderClassification).WithMany(o => o.PurchaseOrderDefaults).HasForeignKey(mp => mp.OrderClassificationId);
            builder.HasOne(m => m.BankAccount).WithMany(o => o.PurchaseOrderDefaults).HasForeignKey(mp => mp.BankAccountId);
            builder.HasOne(m => m.ItemGroup).WithMany(o => o.PurchaseOrderDefaults).HasForeignKey(mp => mp.ItemGroupId);
        }
    }
}
