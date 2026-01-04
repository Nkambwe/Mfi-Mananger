using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlInvoicingDefaultEntityConfiguration {

        public static void Configure(EntityTypeBuilder<InvoicingDefault> builder) {
            builder.ToTable("TBL_MFI_INVOICING_DEFAULTS");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.MultiBranchInvoiceAccount).HasColumnName("multi_branch_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.InvoicingLedger).HasColumnName("invoice_ledger").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.InvoicingAddress).HasColumnName("invoicing_address").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.PriceIncludesSalesTax).HasColumnName("include_sales_tax");
            builder.Property(p => p.PriceIncludesWithHoldingTax).HasColumnName("include_withholding_tax");
            builder.Property(p => p.PriceIncludesVat).HasColumnName("include_vat");
            builder.Property(p => p.TraderId).HasColumnName("trader_id").IsRequired(false);
            builder.Property(p => p.SupplierId).HasColumnName("supplier_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Trader).WithMany(e => e.InvoicingDefaults).HasForeignKey(e => e.TraderId);
            builder.HasOne(p => p.Supplier).WithMany(e => e.InvoicingDefaults).HasForeignKey(e => e.SupplierId);
        }
    }

}
