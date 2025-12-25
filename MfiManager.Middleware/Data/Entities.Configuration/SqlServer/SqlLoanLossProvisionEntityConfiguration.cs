using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanLossProvisionEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanLossProvision> builder) {
            builder.ToTable("TBL_MFI_LOAN_LOSS_PROVISION");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProvisionedOn).HasColumnName("provision_date").IsRequired();
            builder.Property(p => p.Percentage).HasColumnName("percentage").HasPrecision(9,2);
            builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.HasOne(bc => bc.Loan).WithMany(p => p.LossProvisions).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
