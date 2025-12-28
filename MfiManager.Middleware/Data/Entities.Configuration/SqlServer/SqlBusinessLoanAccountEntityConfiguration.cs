using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlBusinessLoanAccountEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<BusinessLoanAccount> builder) {
            builder.ToTable("TBL_MFI_LOAN_ACC_BUSINESS");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.BusinessId).HasColumnName("business_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Business).WithOne(d => d.LoanAccount).HasForeignKey<BusinessLoanAccount>(u => u.BusinessId).IsRequired();
            builder.HasMany(bc => bc.LoanCycles).WithOne(p => p.BusinessAccount).HasForeignKey(bc => bc.BusinessAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.BusinessLoans).WithOne(p => p.LoanAccount).HasForeignKey(bc => bc.LoanAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.BusinessLoans).WithOne(p => p.LoanAccount).HasForeignKey(bc => bc.LoanAccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
