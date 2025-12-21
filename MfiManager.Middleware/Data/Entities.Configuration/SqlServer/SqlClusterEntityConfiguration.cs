using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlClusterEntityConfiguration {

        public static void Configure(EntityTypeBuilder<Cluster> builder) {
            builder.ToTable("TBL_MFI_GROUP_CLUSTER");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Code).HasColumnName("cluster_code").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ClusterName).HasColumnName("cluster_name").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.AddedOn).HasColumnName("added_on");
            builder.Property(p => p.ClosedOn).HasColumnName("closed_on").IsRequired(false);
            builder.Property(p => p.Area).HasColumnName("area").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Merged).HasColumnName("is_merged");
            builder.Property(p => p.MergedTo).HasColumnName("merged_with").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.Active).HasColumnName("is_active");
            builder.Property(p => p.CreditOfficer).HasColumnName("credit_officer").HasColumnType("NVARCHAR(200)").IsRequired();
            builder.Property(p => p.Notes).HasColumnName("notes").HasColumnType("NVARCHAR(MAX)").IsRequired(false);
            builder.Property(p => p.GroupId).HasColumnName("group_id");
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Group).WithMany(o => o.Clusters).HasForeignKey(mp => mp.GroupId);
            builder.HasMany(m => m.Members).WithOne(o => o.Cluster).HasForeignKey(mp => mp.ClusterId);
        }
    }

}
