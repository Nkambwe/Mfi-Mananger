using MfiManager.Middleware.Data.Entities.Accounts.Taxes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTaxGroupEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TaxGroup> builder) {
            builder.ToTable("TBL_MFI_TAX_GROUP");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("code").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.Description).HasColumnName("group_description").HasColumnType("NVARCHAR(MAX)");
            builder.Property(p => p.CustomSeries).HasColumnName("group_series").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(p => p.Products).WithOne(t => t.TaxGroup).HasForeignKey(t => t.TaxGroupId);
            builder.HasMany(p => p.JournalTypes).WithOne(t => t.TaxGroup).HasForeignKey(t => t.JournalTypeId);
            builder.HasMany(p => p.Taxes).WithOne(t => t.TaxGroup).HasForeignKey(t => t.TaxGroupId);
        }
    }
}
