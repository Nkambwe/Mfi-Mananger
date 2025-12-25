using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBranchJournalTypeEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<BranchJournalType> builder) {
            builder.ToTable("TBL_MFI_BRANCH_JOURNAL");
            builder.HasKey(bc => new { bc.BranchId, bc.JournalTypeId });
            builder.Property(bc => bc.BranchId).HasColumnName("branch_id").IsRequired();
            builder.Property(bc => bc.JournalTypeId).HasColumnName("journal_id").IsRequired();
            builder.HasOne(bc => bc.Branch).WithMany(p => p.BranchJournals).HasForeignKey(bc => bc.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.JournalType).WithMany(g => g.BranchJournals).HasForeignKey(bc => bc.JournalTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
