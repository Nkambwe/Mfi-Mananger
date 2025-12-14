using MfiManager.Middleware.Data.Entities.Operations.Timedeposit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTimedepositAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<TimedepositAccount> builder) {
            builder.ToTable("TBL_MFI_TIMEDEPOSIT_ACC");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ProductId).HasColumnName("product_id");
            builder.Property(p => p.BranchId).HasColumnName("branch_id");
            builder.Property(p => p.IndividualId).HasColumnName("person_id").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id").IsRequired(false);
            builder.Property(p => p.AccountNumber).HasColumnName("account_number").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.OpenedOn).HasColumnName("openned_on");
            builder.Property(p => p.DepositAmount).HasColumnName("deposit_amount").HasPrecision(9,2);
            builder.Property(p => p.NegotiatedRate).HasColumnName("neg_rate").HasPrecision(9,2);
            builder.Property(p => p.MaturityValue).HasColumnName("maturity_value").HasPrecision(9,2);
            builder.Property(p => p.MaturityDate).HasColumnName("maturity_date");
            builder.Property(p => p.HoldInterest).HasColumnName("hold_inter");
            builder.Property(p => p.Renewed).HasColumnName("is_renewed");
            builder.Property(p => p.RegisteredBy).HasColumnName("registered_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Product).WithMany(o => o.TimedepositAccounts).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.Branch).WithMany(o => o.TimedepositAccounts).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.IndividualClient).WithMany(o => o.TimedepositAccounts).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.GroupClient).WithMany(o => o.TimedepositAccounts).HasForeignKey(mp => mp.ProductId);
            builder.HasOne(m => m.GroupMember).WithMany(o => o.TimedepositAccounts).HasForeignKey(mp => mp.ProductId);
            builder.HasMany(m => m.Modifications).WithOne(o => o.TimedepositAccount).HasForeignKey(mp => mp.ProductId);
        }
     }

}
