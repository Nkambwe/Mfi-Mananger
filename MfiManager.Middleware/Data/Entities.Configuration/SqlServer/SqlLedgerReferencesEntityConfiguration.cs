using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLedgerReferencesEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LedgerReferences> builder) {
            builder.ToTable("TBL_MFI_LEDGER_REFERENCE");
            builder.HasKey(p => new { p.LedgerAccountId, p.ReferenceId });
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_id").IsRequired();
            builder.Property(p => p.ReferenceId).HasColumnName("ref_id").IsRequired();
            builder.HasOne(mp => mp.LedgerAccount).WithMany(p => p.References).HasForeignKey(mp => mp.LedgerAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(mp => mp.Reference).WithMany(g => g.LedgerAccounts).HasForeignKey(mp => mp.ReferenceId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
