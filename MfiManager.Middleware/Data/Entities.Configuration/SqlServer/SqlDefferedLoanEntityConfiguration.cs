using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDefferedLoanEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<DefferedLoan> builder) {
            builder.ToTable("TBL_MFI_LOAN_DIFFERED");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.StartDate).HasColumnName("start_date").IsRequired();
            builder.Property(p => p.EndDate).HasColumnName("end_date").IsRequired();
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.HasOne(bc => bc.Loan).WithMany(p => p.DefferedLoans).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Reason).WithMany(p => p.DefferedLoans).HasForeignKey(bc => bc.ReasonId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
