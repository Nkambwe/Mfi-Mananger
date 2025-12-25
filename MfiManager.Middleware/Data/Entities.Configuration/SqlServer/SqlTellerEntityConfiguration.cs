using MfiManager.Middleware.Data.Entities.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTellerEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<Teller> builder) {
            builder.ToTable("TBL_MFI_TELLER");
            builder.HasKey(p => p.Id );
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TellerAccount).HasColumnName("teller_account").HasColumnType("NVARCHAR(50)").IsRequired();
            builder.Property(p => p.TransactionLimit).HasColumnName("trans_limit").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.Balance).HasColumnName("balance").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.Active).HasColumnName("is_acivive");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.UserId).HasColumnName("user_id");
            builder.Property(p => p.LedgerAccountId).HasColumnName("ledger_id");
            builder.HasOne(bc => bc.LedgerAccount).WithMany(p => p.Tellers).HasForeignKey(bc => bc.LedgerAccountId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
