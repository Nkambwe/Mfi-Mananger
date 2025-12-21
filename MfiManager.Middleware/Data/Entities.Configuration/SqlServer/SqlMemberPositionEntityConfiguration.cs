using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMemberPositionEntityConfiguration {

        public static void Configure(EntityTypeBuilder<MemberPosition> builder) {
            builder.ToTable("TBL_MFI_MEMBER_POSITION");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Started).HasColumnName("started_on");
            builder.Property(p => p.Ended).HasColumnName("ended_on").IsRequired(false);
            builder.Property(p => p.MemberId).HasColumnName("member_id");
            builder.Property(p => p.PositionId).HasColumnName("position_id");
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(p => p.Position).WithMany(e => e.MemberPositions).HasForeignKey(e => e.PositionId);
            builder.HasOne(p => p.Member).WithMany(e => e.Positions).HasForeignKey(e => e.MemberId);
        }
    }
}
