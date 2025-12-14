namespace MfiManager.Middleware.Utils {
    public class ServerLanguage {
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDefault { get; set; }
        public bool IsRightToLeft { get; set; }

        public List<ServerLanguageResource> Resources { get; protected set; }

        public ServerLanguage() {
            Resources = [];
        }
    }
}
