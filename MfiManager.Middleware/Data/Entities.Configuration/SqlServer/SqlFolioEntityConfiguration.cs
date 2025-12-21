using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlFolioEntityConfiguration {
        public static void Configure(EntityTypeBuilder<Folio> builder) {
            builder.ToTable("TBL_MFI_Folio");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("folio_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.FolioTypeId).HasColumnName("folio_type_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.FolioType).WithMany(o => o.Folios).HasForeignKey(mp => mp.FolioTypeId);
            builder.HasMany(m => m.LedgerAccounts).WithOne(o => o.Folio).HasForeignKey(mp => mp.FolioId);
        }
    }

}
