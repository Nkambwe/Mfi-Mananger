using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTraderInfoEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Trader> builder) {
            builder.ToTable("TBL_MFI_VENDOR");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Name).HasColumnName("vendor_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Alias).HasColumnName("vendor_alias").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Language).HasColumnName("vendor_language").HasColumnType("NVARCHAR(100)");
            builder.Property(p => p.LedgerAccount).HasColumnName("ledger_account").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Priority).HasColumnName("business_priority");
            builder.Property(p => p.Type).HasColumnName("vendor_type");
            builder.Property(p => p.IsSupplier).HasColumnName("is_supplier");
            builder.Property(p => p.GroupId).HasColumnName("category_id").IsRequired(false);
            builder.Property(p => p.DeliverTermsId).HasColumnName("terms_id").IsRequired(false);
            builder.Property(p => p.DeliveryModeId).HasColumnName("mode_id").IsRequired(false);
            builder.Property(p => p.ReasonId).HasColumnName("reason_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Group).WithMany(g => g.Traders).HasForeignKey(bc => bc.GroupId);
            builder.HasOne(p => p.DeliverTerms).WithMany(g => g.Traders).HasForeignKey(bc => bc.DeliverTermsId);
            builder.HasOne(p => p.DeliveryMode).WithMany(g => g.Traders).HasForeignKey(bc => bc.DeliveryModeId);
            builder.HasMany(p => p.SalesTaxes).WithOne(g => g.Vendor).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(p => p.Addresses).WithOne(bc => bc.Vendor).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(p => p.Contacts).WithOne(g => g.Vendor).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(p => p.BankAccounts).WithOne(bc => bc.Vendor).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(p => p.SalesOrderDefault).WithOne(p => p.Vendor).HasForeignKey(a => a.VendorId);
            builder.HasMany(p => p.VendorPaymentDefaults).WithOne(p => p.SupplierVendor).HasForeignKey(a => a.SupplierVendorId);
            builder.HasMany(p => p.CustomerPaymentDefaults).WithOne(p => p.CustomerVendor).HasForeignKey(a => a.CustomerVendorId);
            builder.HasMany(p => p.PurchaseOrderDefaults).WithOne(p => p.Vendor).HasForeignKey(a => a.VendorId);
            builder.HasMany(p => p.HeldContracts).WithOne(bc => bc.Vendor).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(p => p.RefereceValues).WithOne(bc => bc.Vendor).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(p => p.Cards).WithOne(bc => bc.Vendor).HasForeignKey(bc => bc.VendorId);
            
        }
    }
}
