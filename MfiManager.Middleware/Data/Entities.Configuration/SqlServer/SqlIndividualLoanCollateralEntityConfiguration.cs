using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlIndividualLoanCollateralEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<IndividualLoanCollateral> builder) {
            builder.ToTable("TBL_MFI_LOAN_INDIVIDUAL_COLLATERAL");
            builder.HasKey(bc => new { bc.CollateralId, bc.IndividualLoanId });
            builder.Property(bc => bc.CollateralId).HasColumnName("collateral_id").IsRequired();
            builder.Property(bc => bc.IndividualLoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Collateral).WithMany(p => p.IndividualLoans).HasForeignKey(bc => bc.IndividualLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.IndividualLoan).WithMany(g => g.Collaterals).HasForeignKey(bc => bc.CollateralId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
