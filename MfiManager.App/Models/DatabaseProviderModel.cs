namespace MfiManager.App.Models {
    public class DatabaseProviderModel { 
        public string DatabaseProvider {get; set; }
        public string MinimumVersion {get; set; }
        public bool ForceVersionCheck {get; set; }
        public string VersionCheckTime {get; set; }
    }

}
