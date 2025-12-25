using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCashierEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Cashier> builder) {
            builder.ToTable("TBL_MFI_CASHIER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DefaultAccount).HasColumnName("defualt_cash_acc").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.MaximumLimit).HasColumnName("maximum_limit").HasPrecision(9,2);
            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.User).WithMany(o => o.Cashiers).HasForeignKey(mp => mp.UserId);
            builder.HasMany(m => m.CashAccounts).WithOne(o => o.Cashier).HasForeignKey(mp => mp.CashierId);
            builder.HasMany(m => m.CashierJournals).WithOne(o => o.Cashier).HasForeignKey(mp => mp.CashierId);
            builder.HasMany(m => m.CashierVouchers).WithOne(o => o.Cashier).HasForeignKey(mp => mp.CashierId);
        }
    }

}
