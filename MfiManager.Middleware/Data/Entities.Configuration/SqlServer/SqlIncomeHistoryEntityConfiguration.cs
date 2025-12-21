using MfiManager.Middleware.Data.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIncomeHistoryEntityConfiguration {

        public static void Configure(EntityTypeBuilder<IncomeHistory> builder) {
            builder.ToTable("TBL_MFI_INCOMEHISTORY");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Employer).HasColumnName("employer").HasColumnType("NVARCHAR(250)").IsRequired();
            builder.Property(p => p.Position).HasColumnName("position").HasColumnType("NVARCHAR(MAX)").IsRequired();
            builder.Property(p => p.HiredOn).HasColumnName("hired_on").IsRequired();
            builder.Property(p => p.Salary).HasColumnName("salary").HasPrecision(9,2);
            builder.Property(p => p.Current).HasColumnName("is_current");
            builder.Property(p => p.Ended).HasColumnName("ended_on").IsRequired(false);
            builder.Property(p => p.IsDeleted).HasColumnName("is_deleted");
            builder.Property(p => p.CreatedOn).HasColumnName("created_on").IsRequired();
            builder.Property(p => p.CreatedBy).HasColumnName("created_by").HasColumnType("NVARCHAR(10)").IsRequired();
            builder.Property(p => p.ModifiedOn).HasColumnName("modified_on").IsRequired(false);
            builder.Property(p => p.ModifiedBy).HasColumnName("modified_by").HasColumnType("NVARCHAR(10)").IsRequired(false);
            builder.HasOne(m => m.Individual).WithMany(o => o.IncomeHistories).HasForeignKey(mp => mp.IncomeId);
            builder.HasOne(m => m.Member).WithMany(o => o.IncomeHistories).HasForeignKey(mp => mp.MemberId);
            builder.HasOne(m => m.Income).WithMany(o => o.IncomeHistories).HasForeignKey(mp => mp.IncomeId);
        }
    }
}
