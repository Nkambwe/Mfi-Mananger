using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlClusterMemberEntityConfiguration {

        public static void Configure(EntityTypeBuilder<ClusterMember> builder) {
            builder.ToTable("TBL_MFI_GROUP_CLUSTER_MEMBER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Member).HasColumnName("member_code").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.JoinedOn).HasColumnName("joined_on");
            builder.Property(p => p.ExitedOn).HasColumnName("exited_on").IsRequired(false);
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.ClusterId).HasColumnName("cluster_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Cluster).WithMany(o => o.Members).HasForeignKey(mp => mp.ClusterId);
        }
    }

}
