using MfiManager.Middleware.Data.Entities.Operations.Vendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlSupplierBankAccountEntityConfiguration {

        public static void Configure(EntityTypeBuilder<SupplierBankAccount> builder) {
            builder.ToTable("TBL_MFI_SUPPLIER_BANK_ACC");
            builder.HasKey(bc => new { bc.BankAccountId, bc.SupplierId });
            builder.Property(bc => bc.BankAccountId).HasColumnName("account_id").IsRequired();
            builder.Property(bc => bc.SupplierId).HasColumnName("supplier_id").IsRequired();
            builder.HasOne(bc => bc.BankAccount).WithMany(p => p.Suppliers).HasForeignKey(bc => bc.SupplierId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Supplier).WithMany(g => g.BankAccounts).HasForeignKey(bc => bc.BankAccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }

}
