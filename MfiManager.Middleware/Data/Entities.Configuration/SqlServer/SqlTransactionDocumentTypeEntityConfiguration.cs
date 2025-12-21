using MfiManager.Middleware.Data.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {

    public class SqlTransactionDocumentTypeEntityConfiguration {
        public static void Configure(EntityTypeBuilder<TransactionDocumentType> builder) {
            builder.ToTable("TBL_MFI_TRANSACTION_DOCUMENT_TYPE");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("type_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.TypeName).HasColumnName("type_name").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasMany(m => m.SeriesNumbers).WithOne(o => o.DocumentType).HasForeignKey(mp => mp.DocumentTypeId);
            builder.HasMany(m => m.TransactionDocuments).WithOne(o => o.DocumentType).HasForeignKey(mp => mp.DocumentTypeId);
        }
    }

}
