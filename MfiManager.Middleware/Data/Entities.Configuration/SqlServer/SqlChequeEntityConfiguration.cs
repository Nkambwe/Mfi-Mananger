using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlChequeEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Cheque> builder) {
            builder.ToTable("TBL_MFI_CHEQUE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Number).HasColumnName("cheque_number").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.IssuerAccount).HasColumnName("issuer_account").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Recipient).HasColumnName("receipient_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.RecipientAccount).HasColumnName("receipient_account").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
            builder.Property(p => p.AmountInWords).HasColumnName("amount_words").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Status).HasColumnName("cheque_status");
            builder.Property(p => p.Reversed).HasColumnName("is_reversed");
            builder.Property(p => p.BookId).HasColumnName("book_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Book).WithMany(q => q.Cheques).HasForeignKey(q => q.BookId);
        }
    }

}
