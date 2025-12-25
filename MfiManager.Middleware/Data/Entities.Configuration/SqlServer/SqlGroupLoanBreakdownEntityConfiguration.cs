using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlGroupLoanBreakdownEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<GroupLoanBreakdown> builder) {
            builder.ToTable("TBL_MFI_LOAN_GROUPLOAN_BREAKDOWN");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.LoanAmount).HasColumnName("loan_amount").HasPrecision(9,2);
            builder.Property(p => p.LoanInterest).HasColumnName("loan_interest").HasPrecision(9,2);
            builder.Property(p => p.PercentageSaved).HasColumnName("percentage_saved").IsRequired();
            builder.Property(p => p.AmountSaved).HasColumnName("amount_saved");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.HasOne(bc => bc.Loan).WithMany(p => p.GroupLoanBreakdowns).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.MemberId).HasColumnName("member_id");
            builder.HasOne(bc => bc.Member).WithMany(p => p.GroupLoanBreakdowns).HasForeignKey(bc => bc.MemberId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.LoanBreakdownFilter1Id).HasColumnName("filter1_id");
            builder.HasOne(bc => bc.LoanBreakdownFilter1).WithMany(p => p.LoanBreakDowns).HasForeignKey(bc => bc.LoanBreakdownFilter1Id).OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.LoanBreakdownFilter2Id).HasColumnName("filter2_id");
            builder.HasOne(bc => bc.LoanBreakdownFilter2).WithMany(p => p.LoanBreakDowns).HasForeignKey(bc => bc.LoanBreakdownFilter2Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
