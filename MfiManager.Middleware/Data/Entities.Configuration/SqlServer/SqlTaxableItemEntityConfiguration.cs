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
            builder.Property(p => p.TimedepositProductId).HasColumnName("td_pdt_id").IsRequired(false);
            builder.Property(p => p.SavingProductId).HasColumnName("sv_pdt_id").IsRequired(false);
            builder.Property(p => p.ShareProductId).HasColumnName("sh_pdt_id").IsRequired(false);
            builder.Property(p => p.InsuranceProductId).HasColumnName("in_pdt_id").IsRequired(false);
            builder.Property(p => p.LoanProductId).HasColumnName("ln_pdt_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Tax).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.TaxId);
            builder.HasOne(m => m.InsuranceProduct).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.InsuranceProduct);
            builder.HasOne(m => m.SavingProduct).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.SavingProductId);
            builder.HasOne(m => m.ShareProduct).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.ShareProductId);
            builder.HasOne(m => m.TimedepositProduct).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.TimedepositProductId);
            builder.HasOne(m => m.LoanProduct).WithMany(o => o.TaxableItems).HasForeignKey(mp => mp.LoanProductId);
        }
    }
}
