using MfiManager.Middleware.Data.Entities.Operations.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlClaimReceiptEntityConfiguration {
        public static void Configure(EntityTypeBuilder<ClaimReceipt> builder) {
            builder.ToTable("TBL_MFI_CLAIM_RECEIPT");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.PaidOn).HasColumnName("paid_on");
            builder.Property(p => p.Particulars).HasColumnName("particulars").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.Amount).HasColumnName("amount").HasPrecision(9,2);
            builder.Property(p => p.Status).HasColumnName("receipt_status");
            builder.Property(p => p.StatusDate).HasColumnName("status_date");
            builder.Property(p => p.RecordedBy).HasColumnName("recovered_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ApprovedBy).HasColumnName("approved_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ApprovalDate).HasColumnName("approval_date").IsRequired(false);
            builder.Property(p => p.ClaimantId).HasColumnName("claimant_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Claimant).WithMany(o => o.Receipts).HasForeignKey(mp => mp.ClaimantId);
        }
     }
}
