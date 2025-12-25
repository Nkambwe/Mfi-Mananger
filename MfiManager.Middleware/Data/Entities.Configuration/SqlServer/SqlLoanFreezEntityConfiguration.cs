using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanFreezEntityConfiguration {
        public static void Configure(EntityTypeBuilder<LoanFreez> builder) {
            builder.ToTable("TBL_MFI_LOAN_FREEZ");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.FreezDate).HasColumnName("freez_date").IsRequired();
            builder.Property(p => p.PenaltyDate).HasColumnName("penalty_date").IsRequired(false);
            builder.Property(p => p.Penalty).HasColumnName("penalty_amount").HasPrecision(9,2);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.HasOne(bc => bc.Loan).WithMany(p => p.LoanFreez).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Reason).WithMany(p => p.LoanFreezes).HasForeignKey(bc => bc.ReasonId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
