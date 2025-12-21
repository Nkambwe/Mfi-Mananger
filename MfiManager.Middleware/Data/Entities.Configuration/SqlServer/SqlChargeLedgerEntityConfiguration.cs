using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChargeLedgerEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ChargeLedger> builder) {
             builder.ToTable("TBL_MFI_CHARGE_LEDGER");
             builder.HasKey(p => p.Id);
             builder.Property(p => p.Id).HasColumnName("id");
             builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Series).HasColumnName("series").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.Client).HasColumnName("client_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.LoanNumber).HasColumnName("loan_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.PostedOn).HasColumnName("post_on");
             builder.Property(p => p.Product).HasColumnName("product").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.LedgerNumber).HasColumnName("ledger_number").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
             builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
             builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
             builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
             builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
             builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
             builder.Property(p => p.ChargeItemId).HasColumnName("charge_item_id");
             builder.HasOne(m => m.ChargeItem).WithMany(o => o.ChargeTransactions).HasForeignKey(mp => mp.ChargeItemId);
        }
    }
    

}
