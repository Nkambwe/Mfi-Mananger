using MfiManager.App.Defaults;

namespace MfiManager.App.Infrastructure.Settings {
    public class LanguageOptions {
        public const string SectionName = "LanguageOptions";
         public string DefaultCulture  { get; set; } = CommonDefaults.DefaultLanguageCulture;
         public string[] SupportedCultures { get; set; } = [];
    }
}
