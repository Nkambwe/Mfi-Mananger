using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlLoanDeclassifiedEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<LoanDeclassified> builder) {
            builder.ToTable("TBL_MFI_LOAN_DECLASSIFICATION");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Classification).HasColumnName("classification").IsRequired();
            builder.Property(p => p.ClassfiedOn).HasColumnName("classfied_on").IsRequired();
            builder.Property(p => p.DeclassfiedOn).HasColumnName("declassfied_on").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.LoanId).HasColumnName("loan_id");
            builder.HasOne(bc => bc.Loan).WithMany(p => p.DeclassifiedLoans).HasForeignKey(bc => bc.LoanId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
