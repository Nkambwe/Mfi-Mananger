using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTellerJournalTypeEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<TellerJournalType> builder) {
            builder.ToTable("TBL_MFI_TELLER_JOURNAL");
            builder.HasKey(bc => new { bc.TellerId, bc.JournalTypeId });
            builder.Property(bc => bc.TellerId).HasColumnName("teller_id").IsRequired();
            builder.Property(bc => bc.JournalTypeId).HasColumnName("journal_id").IsRequired();
            builder.HasOne(bc => bc.Teller).WithMany(p => p.JournalTypes).HasForeignKey(bc => bc.TellerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.JournalType).WithMany(g => g.TellerJournals).HasForeignKey(bc => bc.JournalTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
