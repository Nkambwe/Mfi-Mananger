using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIndividualLoanAccountEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<IndividualLoanAccount> builder) {
            builder.ToTable("TBL_MFI_LOAN_ACC_INDIVIDUAL");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PersonId).HasColumnName("person_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Individual).WithOne(d => d.LoanAccount).HasForeignKey<IndividualLoanAccount>(u => u.PersonId).IsRequired();
            builder.HasMany(bc => bc.IndividualLoans).WithOne(p => p.LoanAccount).HasForeignKey(bc => bc.LoanAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LoanCycles).WithOne(p => p.IndividualAccount).HasForeignKey(bc => bc.IndividualAccountId).OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
