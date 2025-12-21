using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMemberTransferEntityConfiguration {

        public static void Configure(EntityTypeBuilder<MemberTransfer> builder) {
            builder.ToTable("TBL_MFI_MEMBER_TRANSFER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.ClusterTransfer).HasColumnName("is_cluster_transfer");
            builder.Property(p => p.GroupCode).HasColumnName("group_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TransferFrom).HasColumnName("transfered_from").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.TransferTo).HasColumnName("transfered_to").HasColumnType("NVARCHAR(10)");
            builder.Property(p => p.FromMemberCode).HasColumnName("old_member_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.ToMemberCode).HasColumnName("to_member_code").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.Property(p => p.TransferDate).HasColumnName("transfer_date");
            builder.Property(p => p.Approved).HasColumnName("approved");
            builder.Property(p => p.MemberId).HasColumnName("member_id");
            builder.Property(p => p.ReasonId).HasColumnName("reason_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Reason).WithMany(e => e.MemberTransfers).HasForeignKey(e => e.ReasonId);
            builder.HasOne(p => p.Member).WithMany(e => e.MemberTransfers).HasForeignKey(e => e.MemberId);
        }
    }
}
