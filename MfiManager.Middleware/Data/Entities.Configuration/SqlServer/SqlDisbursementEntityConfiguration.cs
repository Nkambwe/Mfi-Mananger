using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDisbursementEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<Disbursement> builder) {
            builder.ToTable("TBL_MFI_LOAN_DISBURSEMENT");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DisbursementDate).HasColumnName("disbursement_date").IsRequired();
            builder.Property(p => p.DisbursementType).HasColumnName("disbursement_type").IsRequired();
            builder.Property(p => p.DisbursedAmount).HasColumnName("disbursed_amount").HasPrecision(9,2);
            builder.Property(p => p.DisbursedBy).HasColumnName("disbursed_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.Property(p => p.TransactionId).HasColumnName("transaction_id");
            builder.HasOne(bc => bc.Loan).WithMany(p => p.Disbursements).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Transaction).WithMany(p => p.DisbursementTransactions).HasForeignKey(bc => bc.TransactionId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    
}
