using System.Text.Json.Serialization;

namespace MfiManager.App.Infrastructure.MvcHelpers {

    /// <summary>
    /// Redirect user to another URL
    /// </summary>
    public class UserRedirect {
        [JsonPropertyName("success")]
        public bool Success { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }
        [JsonPropertyName("data")]
        public object Data { get; set; }        

        public static UserRedirect Ok(string message = "", object data = null) => new() { Success = true, Message = message, Data = data };

        public static UserRedirect Fail(string message, string redirectUrl = null) => new() { Success = false, Message = message, RedirectUrl = redirectUrl };
    }
}
