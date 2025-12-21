using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanGuarantorEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanGuarantor> builder) {
            builder.ToTable("TBL_MFI_LOAN_GUARANTOR");
            builder.HasKey(bc => new { bc.GuarantorId, bc.LoanId });
            builder.Property(bc => bc.GuarantorId).HasColumnName("guarantor_id").IsRequired();
            builder.Property(bc => bc.LoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Guarantor).WithMany(p => p.Loans).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Loan).WithMany(g => g.Guarantors).HasForeignKey(bc => bc.GuarantorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
