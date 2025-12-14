using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlJournalTypeTaxGroupEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<JournalTypeTaxGroup> builder) {
            builder.ToTable("TBL_MFI_JOURNAL_TAX_GROUP");
            builder.HasKey(bc => new { bc.JournalTypeId, bc.TaxGroupId });
            builder.Property(bc => bc.JournalTypeId).HasColumnName("journal_type_id").IsRequired();
            builder.Property(bc => bc.TaxGroupId).HasColumnName("tax_group_id").IsRequired();
            builder.HasOne(bc => bc.JournalType).WithMany(p => p.TaxGroup).HasForeignKey(bc => bc.JournalTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.TaxGroup).WithMany(g => g.JournalTypes).HasForeignKey(bc => bc.TaxGroupId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
