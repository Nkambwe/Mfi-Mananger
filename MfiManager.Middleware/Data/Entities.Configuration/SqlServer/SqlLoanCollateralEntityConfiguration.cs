using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanCollateralEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanCollateral> builder) {
            builder.ToTable("TBL_MFI_LOAN_COLLATERAL");
            builder.HasKey(bc => new { bc.CollateralId, bc.LoanId });
            builder.Property(bc => bc.CollateralId).HasColumnName("collateral_id").IsRequired();
            builder.Property(bc => bc.LoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Collateral).WithMany(p => p.Loans).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Loan).WithMany(g => g.Collaterals).HasForeignKey(bc => bc.CollateralId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
