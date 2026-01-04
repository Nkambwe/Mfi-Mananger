using MfiManager.Middleware.Data.Entities.Operations.Trade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlPaymentDefaultEntityConfiguration {

        public static void Configure(EntityTypeBuilder<PaymentDefault> builder) {
            builder.ToTable("TBL_MFI_PAYMENT_DEFAULT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.SupplierVendorId).HasColumnName("trader_id");
            builder.Property(p => p.CustomerVendorId).HasColumnName("customer_id").IsRequired(false);
            builder.Property(p => p.PaymentTermsId).HasColumnName("terms_id").IsRequired(false);
            builder.Property(p => p.BankAccountId).HasColumnName("bank_acc_id").IsRequired(false);
            builder.Property(p => p.Method).HasColumnName("payment_method");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SupplierInfo).WithMany(s => s.PaymentDefaults).HasForeignKey(p => p.SupplierId);
            builder.HasOne(u => u.PaymentTerms).WithMany(p => p.PaymentDefaults).HasForeignKey(q => q.PaymentTermsId);
            builder.HasOne(u => u.BankAccount).WithMany(a => a.DefaultVendorPayments).HasForeignKey(u => u.BankAccountId);
        }
    }

}
