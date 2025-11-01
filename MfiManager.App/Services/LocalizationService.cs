using MfiManager.App.Defaults;
using MfiManager.App.Enums;
using MfiManager.App.Infrastructure.Helpers;
using MfiManager.App.Infrastructure.Utils;
using Microsoft.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace MfiManager.App.Services {
    public class LocalizationService(
        ILogger<LocalizationService> logger, 
        IHttpContextAccessor httpContextAccessor,
        IWebHelper webHelper, 
        IMfiFileProvider _fileProvider) : ILocalizationService {

        private  readonly ILogger<LocalizationService> _logger = logger;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private IList<ApplicationLanguage> _availableLanguages;
        private readonly IMfiFileProvider _fileProvider = _fileProvider;
        private readonly IWebHelper _webHelper = webHelper;

        private IList<DatabaseProvider> _providers;
        public IList<ApplicationLanguage> GetAvailableLanguages() {

            try {
                if (_availableLanguages != null)
                    return _availableLanguages;

                _availableLanguages = [];
                foreach (var filePath in _fileProvider.EnumerateFiles(_fileProvider.MapPath("~/Localization/"), "*.xml")) {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(filePath);

                    //get language code
                    var languageCode = "";
                    //we get the file name format: language.{languagecode}.xml
                    var r = new Regex(Regex.Escape("language.") + "(.*?)" + Regex.Escape(".xml"));
                    var matches = r.Matches(_fileProvider.GetFileName(filePath));
                    foreach (Match match in matches) {
                        languageCode = match.Groups[1].Value;
                    }

                    //and now we use language codes only (not full culture names)
                    languageCode = languageCode[..2];
                    var languageNode = xmlDocument.SelectSingleNode(@"//Language");

                    if (languageNode == null || languageNode.Attributes == null)
                        continue;

                    //get language friendly name
                    var languageName = languageNode.Attributes["Name"].InnerText.Trim();
                    //is default
                    var isDefaultAttribute = languageNode.Attributes["IsDefault"];
                    var isDefault = isDefaultAttribute != null && Convert.ToBoolean(isDefaultAttribute.InnerText.Trim());

                    //is default
                    var isRightToLeftAttribute = languageNode.Attributes["IsRightToLeft"];
                    var isRightToLeft = isRightToLeftAttribute != null && Convert.ToBoolean(isRightToLeftAttribute.InnerText.Trim());

                    //create language
                    var language = new ApplicationLanguage {
                        Code = languageCode,
                        Name = languageName,
                        IsDefault = isDefault,
                        IsRightToLeft = isRightToLeft,
                    };

                    //load resources
                    var resources = xmlDocument.SelectNodes(@"//Language/LocaleResource");
                    if (resources == null)
                        continue;
                    foreach (XmlNode resNode in resources) {
                        if (resNode.Attributes == null)
                            continue;

                        var resNameAttribute = resNode.Attributes["Name"];
                        var resValueNode = resNode.SelectSingleNode("Value");

                        if (resNameAttribute == null)
                            throw new Exception("All Language resources must have an attribute Name=\"Value\".");
                        var resourceName = resNameAttribute.Value.Trim();
                        if (string.IsNullOrEmpty(resourceName))
                            throw new Exception("All Language resource attributes 'Name' must have a value.'");

                        if (resValueNode == null)
                            throw new Exception("All Language resources must have an element \"Value\".");
                        var resourceValue = resValueNode.InnerText.Trim();

                        language.Resources.Add(new LanguageResource {
                            Name = resourceName,
                            Value = resourceValue
                        });
                    }

                    _availableLanguages.Add(language);
                    _availableLanguages = [.. _availableLanguages.OrderBy(l => l.Name)];

                }

                return _availableLanguages;
            }catch (Exception ex) { 
                _logger.LogInformation("{Message}", ex.Message);
                _logger.LogInformation("{StackTrace}", ex.StackTrace);
            }
            
            return _availableLanguages;
        }
        
        public IList<DatabaseProvider> GetDatabaseProviders() {
            _providers = [];
            _providers.Add(new DatabaseProvider {
                Code = DbProvider.SqlServer.ToString(),
                Name =DbProvider.SqlServer.GetDescription(),
                
            });
            _providers.Add(new DatabaseProvider {
                Code = DbProvider.PostgreSQL.ToString(),
                Name =DbProvider.PostgreSQL.GetDescription(),
                
            });
            _providers.Add(new DatabaseProvider {
                Code = DbProvider.Oracle.ToString(),
                Name =DbProvider.Oracle.GetDescription(),
             });
            return _providers;
        }

        public ApplicationLanguage GetCurrentLanguage() {
            var httpContext = _httpContextAccessor.HttpContext;

            //..try to get cookie
            var cookieName = $"{CookieDefaults.Prefix}{CookieDefaults.LanguageCookie}";
            httpContext.Request.Cookies.TryGetValue(cookieName, out var cookieLanguageCode);

            //..ensure it's available because it could be deleted
            var availableLanguages = GetAvailableLanguages();
            var language = availableLanguages.FirstOrDefault(l => l.Code.Equals(cookieLanguageCode, StringComparison.InvariantCultureIgnoreCase));
            if (language != null)
                return language;

            //..let's find by current browser culture
            if (httpContext.Request.Headers.TryGetValue(HeaderNames.AcceptLanguage, out var userLanguages)) {
                var userLanguage = userLanguages.FirstOrDefault()?.Split(',').FirstOrDefault() ?? string.Empty;
                if (!string.IsNullOrEmpty(userLanguage)) {
                    //right. we do "StartsWith" (not "Equals") because we have shorten codes (not full culture names)
                    language = availableLanguages.FirstOrDefault(l => userLanguage.StartsWith(l.Code, StringComparison.InvariantCultureIgnoreCase));
                }
            }

            //..let's return the default one
            language = availableLanguages.FirstOrDefault(l => l.IsDefault);
             _logger.LogInformation("DEFAULT LANG :: {Language}", JsonSerializer.Serialize(language));
            if (language != null)
                return language;

            //..return any available language
            language = availableLanguages.FirstOrDefault();
            _logger.LogInformation("ANY LANG :: {Language}", JsonSerializer.Serialize(language));
            return language;
        }

        public string GetLocalizedLabel(string labelName) {
            var language = GetCurrentLanguage();
            if (language == null)
                return labelName;

            var resourceValue = language.Resources
                .Where(r => r.Name.Equals(labelName, StringComparison.InvariantCultureIgnoreCase))
                .Select(r => r.Value).FirstOrDefault();
            if (string.IsNullOrEmpty(resourceValue))
                return labelName;

            return resourceValue;
        }

        public string GetBrowserCulture() {
             _httpContextAccessor.HttpContext.Request.Headers.TryGetValue(HeaderNames.AcceptLanguage, out var userLanguages);
            return userLanguages.FirstOrDefault()?.Split(',').FirstOrDefault() ?? CommonDefaults.DefaultLanguageCulture;
        }

        /// <summary>
        /// Save current language under cookies
        /// </summary>
        /// <param name="languageCode">Language code</param>
        public void SaveCurrentLanguage(string languageCode) {
            var httpContext = _httpContextAccessor.HttpContext;
            var cookieOptions = new CookieOptions {
                Expires = DateTime.Now.AddHours(24),
                HttpOnly = true,
                Secure = _webHelper.IsCurrentConnectionSecured()
            };

            var cookieName = $"{CookieDefaults.Prefix}{CookieDefaults.LanguageCookie}";
            httpContext.Response.Cookies.Delete(cookieName);
            httpContext.Response.Cookies.Append(cookieName, languageCode, cookieOptions);
        }

    }

}
