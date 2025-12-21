using MfiManager.Middleware.Data.Entities.Accounts.Vouchers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlVoucherTypeEntityConfiguration {
        public static void Configure(EntityTypeBuilder<VoucherType> builder) {
             builder.ToTable("TBL_MFI_VOUCHER_TYPE");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.Code).HasColumnName("voucher_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.VoucherName).HasColumnName("voucher_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
             builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.PostingSeries).HasColumnName("posting_series");
             builder.Property(p => p.Posting).HasColumnName("posting_type");
             builder.Property(p => p.System).HasColumnName("is_system");
             builder.Property(p => p.Active).HasColumnName("is_active");
             builder.Property(p => p.StartNumber).HasColumnName("start_number");
             builder.Property(p => p.LastNumber).HasColumnName("last_number");
             builder.Property(p => p.ReasonId).HasColumnName("reason_id");
             builder.Property(p => p.GeneralPostingId).HasColumnName("general_posting_id").IsRequired(false);
             builder.Property(p => p.BusinessPostingId).HasColumnName("business_posting_id").IsRequired(false);
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.HasOne(m => m.Reason).WithMany(o => o.Vouchers).HasForeignKey(mp => mp.ReasonId);
             builder.HasOne(m => m.GeneralPostingItem).WithMany(o => o.Vouchers).HasForeignKey(mp => mp.GeneralPostingId);
             builder.HasOne(m => m.BusinessPostingItem).WithMany(o => o.Vouchers).HasForeignKey(mp => mp.BusinessPostingId);
             builder.HasMany(m => m.CashierVouchers).WithOne(o => o.Voucher).HasForeignKey(mp => mp.VoucherId);
        }
    }
}
