using MfiManager.Middleware.Data.Entities.Accounts.Ledgers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCardLedgerEntityConfiguration {

        public static void Configure(EntityTypeBuilder<CardLedger> builder) {
            builder.ToTable("TBL_MFI_CARD_LEDGER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionId).HasColumnName("trans_id").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Folio).HasColumnName("trans_ref").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.TransDate).HasColumnName("trans_date").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Amount).HasColumnName("trans_amount").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.Card).HasColumnName("card_id");
            builder.Property(p => p.GeneralLedgerTransactionId).HasColumnName("general_ledegr_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Card).WithMany(c => c.Transactions).HasForeignKey(bc => bc.CardId);
            builder.HasOne(u => u.GeneralLedgerTransaction).WithMany(bc => bc.CardTransactions).HasForeignKey(bc => bc.GeneralLedgerTransactionId);
        }
    }
}
