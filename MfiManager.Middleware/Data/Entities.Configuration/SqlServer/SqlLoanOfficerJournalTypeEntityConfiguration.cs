using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanOfficerJournalTypeEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanOfficerJournalType> builder) {
            builder.ToTable("TBL_MFI_LOANOFFICER_JOURNAL");
            builder.HasKey(bc => new { bc.LoanOfficerId, bc.JournalTypeId });
            builder.Property(bc => bc.LoanOfficerId).HasColumnName("officer_id").IsRequired();
            builder.Property(bc => bc.JournalTypeId).HasColumnName("journal_id").IsRequired();
            builder.HasOne(bc => bc.LoanOfficer).WithMany(p => p.JournalTypes).HasForeignKey(bc => bc.LoanOfficerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.JournalType).WithMany(g => g.LoanOfficerJournals).HasForeignKey(bc => bc.JournalTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
