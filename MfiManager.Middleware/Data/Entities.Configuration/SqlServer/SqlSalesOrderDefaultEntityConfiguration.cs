using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSalesOrderDefaultEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SalesOrderDefault> builder) {
            builder.ToTable("TBL_MFI_SALES_ORDER_DEFAULT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Warehouse).HasColumnName("warehouse").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.VendorId).HasColumnName("vendor_id");
            builder.Property(p => p.PriceGroupId).HasColumnName("price_group_id").IsRequired(false);
            builder.Property(p => p.DiscountGroupId).HasColumnName("discount_group_id").IsRequired(false);
            builder.Property(p => p.OrderClassificationId).HasColumnName("order_class_id").IsRequired(false);
            builder.Property(p => p.BankAccountId).HasColumnName("bank_account_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Vendor).WithMany(c => c.SalesOrderDefault).HasForeignKey(bc => bc.VendorId);
            builder.HasOne(m => m.DiscountGroup).WithMany(c => c.SalesOrderDefaults).HasForeignKey(bc => bc.DiscountGroupId);
            builder.HasOne(m => m.PriceGroup).WithMany(c => c.SalesOrderDefaults).HasForeignKey(bc => bc.PriceGroupId);
            builder.HasOne(m => m.OrderClassification).WithMany(c => c.SalesOrderDefaults).HasForeignKey(bc => bc.OrderClassificationId);
            builder.HasOne(m => m.BankAccount).WithMany(c => c.SalesOrderDefaults).HasForeignKey(bc => bc.BankAccountId);
        }
    }
}
