using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChequeBookEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ChequeBook> builder) {
            builder.ToTable("TBL_MFI_CHEQUE_BOOK");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SerialNumber).HasColumnName("serial_number");
            builder.Property(p => p.FirstChequeNumber).HasColumnName("first_cheque_number");
            builder.Property(p => p.LastIssuedCheque).HasColumnName("last_cheque_number");
            builder.Property(p => p.NumberOfLeafs).HasColumnName("cheque_leaves");
            builder.Property(p => p.LastIssuedCheque).HasColumnName("last_issues_leaf");
            builder.Property(p => p.Status).HasColumnName("book_status");
            builder.Property(p => p.BankAccountId).HasColumnName("account_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.BankAccount).WithMany(q => q.Books).HasForeignKey(q => q.BankAccountId);
        }
    }

}
