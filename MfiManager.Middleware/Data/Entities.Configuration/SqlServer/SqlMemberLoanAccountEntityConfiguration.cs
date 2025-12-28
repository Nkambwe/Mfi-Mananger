using MfiManager.Middleware.Data.Entities.Operations.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMemberLoanAccountEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<MemberLoanAccount> builder) {
            builder.ToTable("TBL_MFI_LOAN_ACC_MEMBER");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.MemberId).HasColumnName("member_id");
            builder.Property(p => p.GroupAccountId).HasColumnName("group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Member).WithOne(d => d.LoanAccount).HasForeignKey<MemberLoanAccount>(u => u.MemberId).IsRequired();
            builder.HasOne(bc => bc.GroupAccount).WithMany(p => p.MemberLoanAccounts).HasForeignKey(bc => bc.GroupAccountId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(bc => bc.LoanBreakdowns).WithOne(p => p.MemberAccount).HasForeignKey(bc => bc.MemberAccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
