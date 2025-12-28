using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBusinessLoanCollateralEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<BusinessLoanCollateral> builder) {
            builder.ToTable("TBL_MFI_LOAN_BUSINESS_COLLATERAL");
            builder.HasKey(bc => new { bc.CollateralId, bc.BusinessLoanId });
            builder.Property(bc => bc.CollateralId).HasColumnName("collateral_id").IsRequired();
            builder.Property(bc => bc.BusinessLoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Collateral).WithMany(p => p.BusinessLoans).HasForeignKey(bc => bc.BusinessLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.BusinessLoan).WithMany(g => g.Collaterals).HasForeignKey(bc => bc.CollateralId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
