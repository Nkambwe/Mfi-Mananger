using MfiManager.Middleware.Data.Entities.Operations.Loans;
using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlGroupLoanGuarantorEntityConfiguration {

        public static void Configure(EntityTypeBuilder<GroupLoanGuarantor> builder) {
            builder.ToTable("TBL_MFI_GROUP_LOAN_GUARANTOR");
            builder.HasKey(bc => new { bc.GuarantorId, bc.GroupLoanId });
            builder.Property(bc => bc.GuarantorId).HasColumnName("guarantor_id").IsRequired();
            builder.Property(bc => bc.GroupLoanId).HasColumnName("loan_id").IsRequired();
            builder.HasOne(bc => bc.Guarantor).WithMany(p => p.GroupLoanGuarantors).HasForeignKey(bc => bc.GroupLoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.GroupLoan).WithMany(g => g.Guarantors).HasForeignKey(bc => bc.GuarantorId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
