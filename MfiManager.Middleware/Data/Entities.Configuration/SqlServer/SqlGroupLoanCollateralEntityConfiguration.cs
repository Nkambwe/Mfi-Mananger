using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlGroupLoanCollateralEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<GroupLoanCollateral> builder) {
            builder.ToTable("TBL_MFI_LOAN_GROUP_COLLATERAL");
            builder.HasKey(bc => new { bc.CollateralId, bc.GroupLoanId });
            builder.Property(bc => bc.CollateralId).HasColumnName("collateral_id").IsRequired();
            builder.Property(bc => bc.GroupLoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Collateral).WithMany(p => p.GroupLoans).HasForeignKey(bc => bc.GroupLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.GroupLoan).WithMany(g => g.Collaterals).HasForeignKey(bc => bc.CollateralId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
