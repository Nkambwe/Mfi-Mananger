using MfiManager.Middleware.Data.Entities.Accounts.Cashflows;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlCardEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Card> builder) {
            builder.ToTable("TBL_MFI_CARD");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Holder).HasColumnName("card_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.CardNumber).HasColumnName("card_number").HasColumnType("NVARCHAR(40)").IsRequired();
            builder.Property(p => p.Type).HasColumnName("card_nature").IsRequired();
            builder.Property(p => p.TransactionType).HasColumnName("transaction_type").IsRequired();
            builder.Property(p => p.Freeze).HasColumnName("is_frozen").IsRequired();
            builder.Property(p => p.Limit).HasColumnName("card_limit").HasPrecision(9,2).IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(u => u.Vendor).WithMany(c => c.Cards).HasForeignKey(bc => bc.VendorId);
            builder.HasMany(u => u.Transactions).WithOne(bc => bc.Card).HasForeignKey(bc => bc.CardId);
        }
    }
}
