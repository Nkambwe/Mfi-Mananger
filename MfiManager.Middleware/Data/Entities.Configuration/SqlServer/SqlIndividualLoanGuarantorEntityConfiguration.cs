using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlIndividualLoanGuarantorEntityConfiguration {
        public static void Configure(EntityTypeBuilder<IndividualLoanGuarantor> builder) {
            builder.ToTable("TBL_MFI_INDIVIDUAL_LOAN_GUARANTOR");
            builder.HasKey(bc => new { bc.GuarantorId, bc.IndividualLoanId });
            builder.Property(bc => bc.GuarantorId).HasColumnName("guarantor_id").IsRequired();
            builder.Property(bc => bc.IndividualLoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Guarantor).WithMany(p => p.IndividualLoanGuarantors).HasForeignKey(bc => bc.IndividualLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.IndividualLoan).WithMany(g => g.Guarantors).HasForeignKey(bc => bc.GuarantorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
