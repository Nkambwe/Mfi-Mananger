using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlSupplierInfoEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SupplierInfo> builder) {
            builder.ToTable("TBL_MFI_SUPPLIER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Name).HasColumnName("supplier_name").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Alias).HasColumnName("supplier_alias").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.Language).HasColumnName("supplier_language").HasColumnType("NVARCHAR(100)");
            builder.Property(p => p.LedgerAccount).HasColumnName("ledger_account").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Priority).HasColumnName("business_priority");
            builder.Property(p => p.Employees).HasColumnName("employee_no");
            builder.Property(p => p.Type).HasColumnName("supplier_type");
            builder.Property(p => p.IsClient).HasColumnName("is_customer");
            builder.Property(p => p.ClientCode).HasColumnName("customer_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.DeliveryLocation).HasColumnName("delivery_local").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.DeliverTermsId).HasColumnName("delivery_terms_id").IsRequired(false);
            builder.Property(p => p.DeliveryModeId).HasColumnName("delivery_mode_id").IsRequired(false);
            builder.Property(p => p.SupplierGroupId).HasColumnName("supplier_group_id").IsRequired(false);
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SupplierGroup).WithMany(g => g.Suppliers).HasForeignKey(bc => bc.SupplierGroupId);
            builder.HasOne(p => p.DeliverTerms).WithMany(g => g.Suppliers).HasForeignKey(bc => bc.DeliverTermsId);
            builder.HasOne(p => p.DeliveryMode).WithMany(g => g.Suppliers).HasForeignKey(bc => bc.DeliveryModeId);
            builder.HasMany(p => p.SalesTaxes).WithOne(g => g.Supplier).HasForeignKey(bc => bc.SupplierId);
            builder.HasMany(p => p.Addresses).WithOne(bc => bc.Supplier).HasForeignKey(bc => bc.SupplierId);
            builder.HasMany(p => p.Contacts).WithOne(g => g.Supplier).HasForeignKey(bc => bc.SupplierId);
            builder.HasMany(p => p.BankAccounts).WithOne(bc => bc.Supplier).HasForeignKey(bc => bc.SupplierId);
            builder.HasMany(p => p.PurchaseOrderDefaults).WithOne(p => p.Supplier).HasForeignKey(a => a.SupplierId);
            builder.HasMany(p => p.PaymentDefaults).WithOne(p => p.SupplierInfo).HasForeignKey(a => a.SupplierVendorId);
            builder.HasMany(p => p.HeldContracts).WithOne(bc => bc.Supplier).HasForeignKey(bc => bc.SupplierId);
            builder.HasMany(p => p.SupplierReferences).WithOne(bc => bc.Supplier).HasForeignKey(bc => bc.SupplierId);
            builder.HasMany(p => p.SuppliedBranches).WithOne(bc => bc.SupplierInfo).HasForeignKey(bc => bc.SupplierId);

        }
    }
}
