using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBranchRevolvingFundEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<BranchRevolvingFund> builder) {
            builder.ToTable("TBL_MFI_BRANCH_REVOLVING_FUND");
            builder.HasKey(bc => new { bc.BranchId, bc.FundId });
            builder.Property(bc => bc.BranchId).HasColumnName("branch_id").IsRequired();
            builder.Property(bc => bc.FundId).HasColumnName("fund_id").IsRequired();
            builder.HasOne(bc => bc.Branch).WithMany(p => p.RevolvingFunds).HasForeignKey(bc => bc.BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.RevolvingFund).WithMany(g => g.Branches).HasForeignKey(bc => bc.FundId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
