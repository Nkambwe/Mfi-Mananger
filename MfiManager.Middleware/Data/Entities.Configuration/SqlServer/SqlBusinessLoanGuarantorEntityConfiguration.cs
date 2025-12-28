using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBusinessLoanGuarantorEntityConfiguration {
        public static void Configure(EntityTypeBuilder<BusinessLoanGuarantor> builder) {
            builder.ToTable("TBL_MFI_BUSINESS_LOAN_GUARANTOR");
            builder.HasKey(bc => new { bc.GuarantorId, bc.BusinessLoanId });
            builder.Property(bc => bc.GuarantorId).HasColumnName("guarantor_id").IsRequired();
            builder.Property(bc => bc.BusinessLoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Guarantor).WithMany(p => p.BusinessLoanGuarantors).HasForeignKey(bc => bc.BusinessLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.BusinessLoan).WithMany(g => g.Guarantors).HasForeignKey(bc => bc.GuarantorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
