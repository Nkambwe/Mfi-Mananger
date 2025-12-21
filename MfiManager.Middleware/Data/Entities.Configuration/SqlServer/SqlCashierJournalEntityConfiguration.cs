using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCashierJournalEntityConfiguration {
        public static void Configure(EntityTypeBuilder<CashierJournal> builder) {
            builder.ToTable("TBL_MFI_CASHIER_JOURNAL");
            builder.HasKey(bc => new { bc.CashierId, bc.JournalId });
            builder.Property(bc => bc.CashierId).HasColumnName("cashier_id").IsRequired();
            builder.Property(bc => bc.JournalId).HasColumnName("journal_id").IsRequired();
            builder.HasOne(bc => bc.Cashier).WithMany(p => p.CashierJournals).HasForeignKey(bc => bc.CashierId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Journal).WithMany(g => g.CashierJournals).HasForeignKey(bc => bc.JournalId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
