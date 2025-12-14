using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTraderBankAccountEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<TraderBankAccount> builder) {
            builder.ToTable("TBL_MFI_VENDOR_BANK_ACC");
            builder.HasKey(bc => new { bc.BankAccountId, bc.VendorId });
            builder.Property(bc => bc.BankAccountId).HasColumnName("account_id").IsRequired();
            builder.Property(bc => bc.VendorId).HasColumnName("vendor_id").IsRequired();
            builder.HasOne(bc => bc.BankAccount).WithMany(p => p.Traders).HasForeignKey(bc => bc.VendorId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Vendor).WithMany(g => g.BankAccounts).HasForeignKey(bc => bc.BankAccountId).OnDelete(DeleteBehavior.Cascade);
        }

    }

}
