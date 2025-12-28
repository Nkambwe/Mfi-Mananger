using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMemberAccountBreakdownsEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<MemberAccountBreakdown> builder) {
            builder.ToTable("TBL_MFI_LOAN_MEMBER_ACC_BREAKDOWN");
            builder.HasKey(bc => new { bc.MemberAccountId, bc.LoanBreakdownId });
            builder.Property(bc => bc.MemberAccountId).HasColumnName("member_acc_id").IsRequired();
            builder.Property(bc => bc.LoanBreakdownId).HasColumnName("lnr_breakdown_id").IsRequired();
            builder.HasOne(bc => bc.MemberAccount).WithMany(p => p.LoanBreakdowns).HasForeignKey(bc => bc.MemberAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.LoanBreakdown).WithMany(g => g.MemberAccounts).HasForeignKey(bc => bc.LoanBreakdownId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
