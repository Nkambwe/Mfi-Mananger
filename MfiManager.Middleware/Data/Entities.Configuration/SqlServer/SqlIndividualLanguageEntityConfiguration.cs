using MfiManager.Middleware.Data.Entities.Support;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MfiManager.Middleware.Data.Entities.Configuration.SqlServer {
    public class SqlIndividualLanguageEntityConfiguration {
        
        public static void Configure(EntityTypeBuilder<IndividualLanguage> builder) {
            builder.ToTable("TBL_MFI_INDIVIDUAL_LANGUAGE");
            builder.HasKey(bc => new { bc.IndividualId, bc.LanguageId });
            builder.Property(bc => bc.IndividualId).HasColumnName("individual_id").IsRequired();
            builder.Property(bc => bc.LanguageId).HasColumnName("language_id").IsRequired();
            builder.HasOne(bc => bc.Individual).WithMany(p => p.Languages).HasForeignKey(bc => bc.LanguageId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bc => bc.Language).WithMany(g => g.Individuals).HasForeignKey(bc => bc.IndividualId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
