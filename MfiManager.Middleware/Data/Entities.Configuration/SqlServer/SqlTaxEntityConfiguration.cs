using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTaxEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Tax> builder) {
            builder.ToTable("TBL_MFI_TAX");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("tax_code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Description).HasColumnName("tax_description").HasColumnType("NVARCHAR(200)");
            builder.Property(p => p.IsRated).HasColumnName("is_percentage");
            builder.Property(p => p.Rate).HasColumnName("per_rate").HasPrecision(19,2);
            builder.Property(p => p.FlatAmount).HasColumnName("flat_amount").HasPrecision(19,2);
            builder.Property(p => p.Suspend).HasColumnName("is_suspended");
            builder.Property(p => p.Notes).HasColumnName("tax_note").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.TaxGroupId).HasColumnName("tax_group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.TaxGroup).WithMany(o => o.Taxes).HasForeignKey(mp => mp.TaxGroupId);
            builder.HasMany(m => m.Suppliers).WithOne(o => o.Tax).HasForeignKey(mp => mp.TaxId);
            builder.HasMany(m => m.TaxableItems).WithOne(o => o.Tax).HasForeignKey(mp => mp.TaxId);
            builder.HasMany(m => m.Vendors).WithOne(o => o.Tax).HasForeignKey(mp => mp.TaxId);
            builder.HasMany(m => m.ChargedItems).WithOne(o => o.Tax).HasForeignKey(mp => mp.TaxId);
        }
    }
}
