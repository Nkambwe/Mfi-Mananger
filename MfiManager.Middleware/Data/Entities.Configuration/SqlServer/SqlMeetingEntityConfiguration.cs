using MfiManager.Middleware.Data.Entities.Customers.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMeetingEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Meeting> builder) {
            builder.ToTable("TBL_MFI_GROUP_MEETING");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.MeetingDays).HasColumnName("meeting_days").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.MeetingTime).HasColumnName("meeting_time").HasColumnType("NVARCHAR(180)").IsRequired();
            builder.Property(p => p.MeetingsHeld).HasColumnName("meetings");
            builder.Property(p => p.Frequency).HasColumnName("frequency");
            builder.Property(p => p.GroupId).HasColumnName("group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            
            builder.HasOne(m => m.Group).WithMany(o => o.Meetings).HasForeignKey(mp => mp.GroupId);
        }
    }
}
