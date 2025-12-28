using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlGroupLoanAccountEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<GroupLoanAccount> builder) {
            builder.ToTable("TBL_MFI_LOAN_ACC_GROUP");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.GroupId).HasColumnName("group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Group).WithOne(d => d.LoanAccount).HasForeignKey<GroupLoanAccount>(u => u.GroupId).IsRequired();
            builder.HasMany(bc => bc.LoanCycles).WithOne(p => p.GroupAccount).HasForeignKey(bc => bc.IndividualAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.GroupLoans).WithOne(p => p.LoanAccount).HasForeignKey(bc => bc.LoanAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.MemberLoanAccounts).WithOne(p => p.GroupAccount).HasForeignKey(bc => bc.GroupAccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
