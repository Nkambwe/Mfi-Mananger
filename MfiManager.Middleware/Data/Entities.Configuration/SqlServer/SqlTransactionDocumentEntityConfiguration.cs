using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlTransactionDocumentEntityConfiguration {
        public static void Configure(EntityTypeBuilder<TransactionDocument> builder) {
            builder.ToTable("TBL_MFI_TRANSACTION_DOCUMENT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.TransactionCode).HasColumnName("trans_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.DocumentNumber).HasColumnName("document_number").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.DocumentName).HasColumnName("document_name").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.DocumentTypeId).HasColumnName("document_type_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.DocumentType).WithMany(o => o.TransactionDocuments).HasForeignKey(mp => mp.DocumentTypeId);
            builder.HasMany(m => m.VoucherTransactions).WithOne(o => o.TransactionDocument).HasForeignKey(mp => mp.TransactionDocumentId);
        }
    }

}
