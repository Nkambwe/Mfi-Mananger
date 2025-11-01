using MfiManager.App.Infrastructure.Utils;

namespace MfiManager.App.Services {

    public interface ILocalizationService {
        /// <summary>
        /// Get language resource
        /// </summary>
        /// <param name="labelName">Language label name</param>
        /// <returns>Language label value</returns>
        string GetLocalizedLabel(string labelName);

        /// <summary>
        /// Get a list of available languages
        /// </summary>
        /// <returns></returns>
        IList<ApplicationLanguage> GetAvailableLanguages();

        /// <summary>
        /// Get current selected language
        /// </summary>
        /// <returns></returns>
        ApplicationLanguage GetCurrentLanguage();
        
        /// <summary>
        /// Get a list of available database providers
        /// </summary>
        /// <returns></returns>
        IList<DatabaseProvider> GetDatabaseProviders();

        /// <summary>
        /// Save a language for the System
        /// </summary>
        /// <param name="languageCode">Language code</param>
        void SaveCurrentLanguage(string languageCode);
    }

}
