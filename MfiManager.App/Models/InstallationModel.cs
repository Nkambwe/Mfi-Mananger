namespace MfiManager.App.Models {
    public class InstallationModel {

        public CompanyModel Company { get; set; }

        public CompanyUserModel Owner { get; set; }
        
        public DatabaseProviderModel DatabaseProvider { get; set; }
        
        public string ApplicationLanguage { get; set; }

    }
}
