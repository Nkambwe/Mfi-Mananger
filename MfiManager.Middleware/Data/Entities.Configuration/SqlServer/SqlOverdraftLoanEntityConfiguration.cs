using MfiManager.Middleware.Data.Entities.Operations.Saving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlOverdraftLoanEntityConfiguration {

        public static void Configure(EntityTypeBuilder<OverdraftLoan> builder) {
            builder.ToTable("TBL_MFI_OVERDRAFT_LOAN");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.RequestDate).HasColumnName("request_date");
            builder.Property(p => p.TranstypeId).HasColumnName("trans_type_id").IsRequired(false);
            builder.Property(p => p.Transcode).HasColumnName("trans_code");
            builder.Property(p => p.OverdraftNumber).HasColumnName("overdraft_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.LedgerAccount).HasColumnName("ledger_account").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
            builder.Property(p => p.Interest).HasColumnName("interest").HasPrecision(9,2);
            builder.Property(p => p.InterestStartDate).HasColumnName("start_date");
            builder.Property(p => p.SettlementDate).HasColumnName("settlement_date");
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.ProcessedBy).HasColumnName("processed_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ApprovedOn).HasColumnName("approved_date").IsRequired(false);
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.EntryDate).HasColumnName("entry_date");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.SavingAccount).WithMany(e => e.Overdrafts).HasForeignKey(e => e.SavingAccountId);
            builder.HasMany(p => p.Guarantees).WithOne(e => e.Overdraft).HasForeignKey(e => e.OverdraftId);
            builder.HasMany(p => p.Modifications).WithOne(e => e.Overdraft).HasForeignKey(e => e.OverdraftId);
        }
    }

}
