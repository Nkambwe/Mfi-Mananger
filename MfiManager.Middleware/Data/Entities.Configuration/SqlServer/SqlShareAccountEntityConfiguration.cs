using MfiManager.Middleware.Data.Entities.Operations.Shares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlShareAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ShareAccount> builder) {
            builder.ToTable("TBL_MFI_SHARE_ACC");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.AccountNumber).HasColumnName("account_number").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.OpenedOn).HasColumnName("opened_on").IsRequired();
            builder.Property(p => p.Shares).HasColumnName("shares").IsRequired();
            builder.Property(p => p.TotalValue).HasColumnName("total_values").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.ClosedOn).HasColumnName("closed_on").IsRequired(false);
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.IndividualId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Branch).WithMany(o => o.ShareAccounts).HasForeignKey(mp => mp.BranchId);
            builder.HasOne(m => m.Product).WithMany(o => o.ShareAccounts).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.IndividualClient).WithMany(o => o.ShareAccounts).HasForeignKey(mp => mp.IndividualId);
            builder.HasOne(m => m.Member).WithMany(o => o.ShareAccounts).HasForeignKey(mp => mp.MemberId);
            builder.HasMany(m => m.ShareTransactions).WithOne(o => o.ShareAccount).HasForeignKey(mp => mp.ShareAccountId);
            builder.HasMany(m => m.DividendTransactions).WithOne(o => o.ShareAccount).HasForeignKey(mp => mp.ShareAccountId);
        }
    }

}
