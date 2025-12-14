using MfiManager.Middleware.Data.Entities.Operations.Shares;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlDividendLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<DividendTransactionLedger> builder) {
            builder.ToTable("TBL_MFI_SHARE_DIVIDEND");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Ledger).HasColumnName("ledger_acc").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.PaidOn).HasColumnName("pay_date");
            builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.Outstanding).HasColumnName("outstanding").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.ShareAccountId).HasColumnName("share_acc_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.ShareAccount).WithMany(o => o.DividendTransactions).HasForeignKey(mp => mp.ShareAccountId);
        }
    }

}
