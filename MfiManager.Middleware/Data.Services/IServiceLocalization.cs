using MfiManager.Middleware.Utils;

namespace MfiManager.Middleware.Data.Services {

    public interface IServiceLocalization {
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
        IList<ServerLanguage> GetAvailableLanguages();

        /// <summary>
        /// Get current selected language
        /// </summary>
        /// <returns></returns>
        ServerLanguage GetCurrentLanguage();

        /// <summary>
        /// Save a language for the System
        /// </summary>
        /// <param name="languageCode">Language code</param>
        void SaveCurrentLanguage(string languageCode);
    }

}
