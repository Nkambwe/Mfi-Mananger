using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlMemberLanguageEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<MemberLanguage> builder) {
            builder.ToTable("TBL_MFI_MEMBER_LANGUAGE");
            builder.HasKey(bc => new { bc.MemberId, bc.LanguageId });
            builder.Property(bc => bc.MemberId).HasColumnName("member_id").IsRequired();
            builder.Property(bc => bc.LanguageId).HasColumnName("language_id").IsRequired();
            builder.HasOne(bc => bc.Member).WithMany(p => p.Languages).HasForeignKey(bc => bc.LanguageId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Language).WithMany(g => g.Members).HasForeignKey(bc => bc.MemberId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
