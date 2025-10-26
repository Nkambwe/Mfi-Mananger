namespace MfiManager.App.Infrastructure.Utils {
    public class ApplicationLanguage {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDefault { get; set; }
        public bool IsRightToLeft { get; set; }

        public List<LanguageResource> Resources { get; protected set; }

        public ApplicationLanguage() {
            Resources = [];
        }
    }
}
